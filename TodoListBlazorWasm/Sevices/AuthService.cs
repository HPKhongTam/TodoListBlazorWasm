﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;
using TodoList.Models;

namespace TodoListBlazorWasm.Sevices
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {

            var result = await _httpClient.PostAsJsonAsync("/api/login", loginRequest);
            var content =  result.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content.ToString(),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            if (!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await _localStorage.SetItemAsync("authToken", loginResponse.Token);
            ((ApiAuthentiactionStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthentiactionStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
