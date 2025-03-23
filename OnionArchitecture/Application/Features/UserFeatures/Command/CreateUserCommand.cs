using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = command.UserName,
                PasswordSalt = GenerateSalt(),
                PasswordHash = HashPassword(command.Password)
            };

            _context.Users.Add(user);
        //    await _context.SaveChanges(cancellationToken);
            return user.Id;
        }

        private byte[] GenerateSalt()
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            return hmac.Key;
        }

        private byte[] HashPassword(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(GenerateSalt());
            return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
