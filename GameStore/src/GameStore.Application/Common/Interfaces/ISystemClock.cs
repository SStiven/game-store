﻿namespace GameStore.Application.Common.Interfaces;

public interface ISystemClock
{
    DateTimeOffset UtcNow { get; }
}
