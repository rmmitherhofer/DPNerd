﻿namespace DPNerd.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
