using Application.ViewModels.Customer;
using Application.ViewModels.Movie;
using AutoMapper;
using Domain.Models;


namespace Application.Mappers
{
    public class FlixmovieProfile: Profile
    {
        public FlixmovieProfile()
        {
            CreateMap<Movie, MovieViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
        }
    }
}
