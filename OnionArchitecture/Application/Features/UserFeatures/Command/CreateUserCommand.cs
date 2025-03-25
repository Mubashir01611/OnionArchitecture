using System.Security.Cryptography;
using System.Text;
using Application.DTOs.User;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
       public RegisterDto registerDto { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = command.registerDto.Name.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(command.registerDto.Password)),
                PasswordSalt = hmac.Key,
            };

            await _userRepository.AddUserAsync(user);
            return user.Id;
        }

    }
}
