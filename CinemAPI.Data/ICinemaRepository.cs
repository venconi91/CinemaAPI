using CinemAPI.Models;
using CinemAPI.Models.Contracts.Cinema;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface ICinemaRepository
    {
        ICinema GetByNameAndAddress(string name, string address);

        void Insert(ICinemaCreation cinema);

        ICollection<ICinema> GetAll();
    }
}