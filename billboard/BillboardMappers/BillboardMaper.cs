﻿using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Billboard;
using billboard.Model.Dtos.Company;
using billboard.Model.Dtos.Game;
using billboard.Model.Dtos.Lessor;
using billboard.Model.Dtos.NaturalPerson;
using billboard.Model.Dtos.Permissions;
using billboard.Model.Dtos.Person;
using billboard.Model.Dtos.Rental;
using billboard.Model.Dtos.Tenant;
using billboard.Model.Dtos.User;
using billboard.Model.Dtos.UserTypes;
using billboard.Model.Dtos.UserTypeXPermissions;

namespace billboard.BillboardMappers
{
    public class BillboardMaper : Profile
    {
        public BillboardMaper()
        {
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<UserTypePermissions, UserType_PermissionsDto>().ReverseMap();
            CreateMap<UserType, UserTypeDto>().ReverseMap();
            CreateMap<UserType, CreateUserTypeDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, CreatePersonDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<Tenant, TenantDto>().ReverseMap();
            CreateMap<Tenant, CreateTenantDto>().ReverseMap();
            CreateMap<Lessor, LessorDto>().ReverseMap();
            CreateMap<Lessor, CreateLessorDto>().ReverseMap();
            CreateMap<Company, ShowCompanyDto>().ReverseMap();
            CreateMap<Company, RegisterCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompany>().ReverseMap();
            CreateMap<Billboard, ShowBillboardDto>().ReverseMap();
            CreateMap<Billboard, CreateBillboardDto>().ReverseMap();
            CreateMap<Rental, ShowRentalDto>().ReverseMap();
            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<(User user, Person person), LogInNaturalPerson>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.person.Email))
                .ForMember(dest => dest.PeoplePassword, opt => opt.MapFrom(src => src.user.PeoplePassword));
            CreateMap<Company, LoginCompanyDto>().ReverseMap();
            CreateMap<Game, ShowGameDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
    
}
