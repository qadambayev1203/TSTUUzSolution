﻿using Newtonsoft.Json;

namespace Entities.Model.AnyClasses;

public class OAuth2TokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }
}
