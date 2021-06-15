using Huntress.Api.Models;
using System;

namespace Huntress.Api.Features
{
    public class SocialShareDto
    {
        public Guid SocialShareId { get; set; }
        public SocialShareType ShareType { get; set; } = SocialShareType.Facebook;
        public string Url { get; set; }
    }
}
