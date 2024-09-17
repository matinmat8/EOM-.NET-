using Grpc.Core;
using Microsoft.AspNetCore.Identity;

public class AuthServiceImpl : AuthService.AuthServiceBase {
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ILogger<AuthServiceImpl> _logger;
    
    public AuthServiceImpl(ITokenService tokenService, UserManager<ApplicationUser> userManager, ILogger<AuthServiceImpl> logger) {
        _tokenService = tokenService;
        _userManager = userManager;
        _logger = logger;
    }

    public override async Task<AuthResponse> Login(LoginRequest request, ServerCallContext context) {
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user == null) {
        
        return new AuthResponse
            {
                Token = "",
                Success = false,
                Message = "Invalid username or password."
            };
        }
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed) {
            return new AuthResponse {
                Token = "",
                Success = false,
                Message = "Invalid username or password."
            };
        }
        _logger.LogInformation("Received gRPC request: {Request}", request);
        var token = _tokenService.GenerateToken(request.Username, user.Email);
        return await Task.FromResult(new AuthResponse { Token = token, Success=true, Message="Done!" });

    }


    public override async Task<AuthResponse> SignUp(SignUpRequest request, ServerCallContext context) {
        Console.WriteLine($"Received sign-up request: Username={request.Username}, Email={request.Email}");
        var user = new ApplicationUser
        {
            UserName = request.Username,
            Email = request.Email
        };
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

        var result = await _userManager.CreateAsync(user);

        if (!result.Succeeded) {
            Console.WriteLine(result.Errors);
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return new AuthResponse {
                Token = "",
                Success = false,
                Message = $"User creation failed: {errors}"

            };
        }

        var token = _tokenService.GenerateToken(request.Username, request.Email);
        return await Task.FromResult(new AuthResponse {Token = token, Message = "added", Success = true});
    }
}