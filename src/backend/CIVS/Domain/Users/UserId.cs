﻿using StrongIDs;

namespace Domain.Users;

public readonly partial record struct UserId : IStrongId<UserId>;