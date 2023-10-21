﻿
using Backend.Models.Accounts;

namespace Backend.Models.Users;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}