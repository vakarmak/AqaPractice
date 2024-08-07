﻿using PlaywrightSpecFlow.ApiTesting.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace PlaywrightSpecFlow.ApiTesting.Account
{
    internal class AccountApi
    {
        private readonly HttpClient _client;

        public AccountApi(string baseUrl)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<string> AddUserAndGetId(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("Account/v1/User", content);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null!;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<User>(responseContent);

            Console.WriteLine("User created successfully.");
            return createdUser!.UserId;
        }

        public async Task<string?> GenerateToken(UserModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsync("Account/v1/GenerateToken", content);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseToken = JsonConvert.DeserializeObject<UserToken>(responseContent);

            return responseToken!.Token;
        }

        public async Task<HttpResponseMessage> GetUserById(string userId, string token)
        {
            using var requestMessage =
                new HttpRequestMessage(HttpMethod.Get, _client.BaseAddress + "Account/v1/User/" + userId);
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return await _client.SendAsync(requestMessage);
        }

        public async Task DeleteAccountById(string id, string token)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, _client.BaseAddress + "Account/v1/User/" + id);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.SendAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent), "Account deletion failed.");
        }
    }
}
