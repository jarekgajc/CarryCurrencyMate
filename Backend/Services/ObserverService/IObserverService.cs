﻿using Common.Models.Observer;

namespace Backend.Services.ObserverService
{
    public interface IObserverService
    {
        Task<Observer> CreateObserver(Observer observer);
        Task<bool> DeleteObserver(long id);
        Task<Observer?> GetObserver(long id);
        Task<List<Observer>> GetObservers();
        Task<Observer> UpdateObserver(long id, Observer observer);
    }
}