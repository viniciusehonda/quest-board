﻿using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace QuestBoard.Core;

public class User(string firstName, string lastName, string email) : EntityBase, IAggregateRoot
{
    public string FirstName { get; private set; } = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    public string LastName { get; private set; } = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    public string Email { get; private set; } = Guard.Against.NullOrEmpty(email, nameof(email));
    public Password? Password { get; private set; }

    public List<Quest> CreatedQuests = [];

    public void UpdateFirstName(string firstName) {
        FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    }

    public void UpdateLastName(string lastName) {
        LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    }

    public void UpdateEmail(string email) {
        Email = Guard.Against.NullOrEmpty(email, nameof(email));
    }

    public void UpdatePassword(string inputPassword) {

        Password = new Password("", "");
        Password.HashPassword(inputPassword);
    }
}
