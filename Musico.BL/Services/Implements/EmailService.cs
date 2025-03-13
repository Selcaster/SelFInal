using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Musico.BL.DTOs.Options;
using Musico.BL.ExternalServices.Interfaces;
using Musico.Core.Entities;
using Musico.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Musico.BL.Services;

public class EmailService:IEmailService
{
    readonly SmtpClient _client;
    readonly MailAddress _from;
    readonly IUserRepository _repo;
    readonly ICurrentUser _user;
    readonly IMemoryCache _cache;
    readonly IHttpContextAccessor _httpContextAccessor;
    public EmailService(IOptions<EmailOptions> options,
        IMemoryCache cache,
        IHttpContextAccessor httpContextAccessor,
        IUserRepository repo,
        ICurrentUser user)
    {
        var opt = options.Value;
        _client = new(opt.Host, opt.Port);
        _client.Credentials = new NetworkCredential(opt.Sender, opt.Password);
        _client.EnableSsl = true;
        _from = new MailAddress(opt.Sender,"Selcan");
        _cache = cache;
        _httpContextAccessor = httpContextAccessor;
        _repo = repo;
        _user = user;
    }
    public async Task SendEmailConfirmation()
    {
        string? email = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        string? name = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }
       
        var token = Guid.NewGuid().ToString();
        _cache.Set(name, token, TimeSpan.FromMinutes(10));
        MailAddress to = new(email);
        MailMessage msg = new(_from, to);
        msg.Subject = "Confirm your email address";
        msg.Body = token;
        await _client.SendMailAsync(msg);
    }

    public async Task AccountVerify(string userToken)
    {
        string? name = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        
        User? user = await _repo.GetByIdAsync(_user.GetId());
        //user!.Role = user!.Roles | (int)Roles.Publisher;
        await _repo.SaveAsync();
    }

}