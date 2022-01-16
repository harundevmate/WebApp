using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBase.Models
{
    public class JwtSettingModel
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
        public TimeSpan RefreshTokenLifeTime { get; set; }
    }
}
