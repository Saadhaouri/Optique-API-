using AutoMapper;
using Core.App.Dto;
using Core.App.Dto.AchatDTO;
using Core.App.Dto.Auth;
using Core.App.Dto.OrderDTO;
using Core.App.Dto.ProductDTO;
using Core.App.Dto.VenteDTO;
using Optique_Domaine.Entities;
using OptiqueAPI.ViewModels;
using OptiqueAPI.ViewModels.Achat;
using OptiqueAPI.ViewModels.Auth;
using OptiqueAPI.ViewModels.Category;
using OptiqueAPI.ViewModels.Facture;
using OptiqueAPI.ViewModels.Fornisseur;
using OptiqueAPI.ViewModels.Order;
using OptiqueAPI.ViewModels.Product;
using OptiqueAPI.ViewModels.Vente;
using OptiqueAPI.ViewModels.Visite;

namespace OptiqueAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        // Visite mappings
        CreateMap<Visite, VisiteDto>().ReverseMap();
        CreateMap<Visite, CreateUpdateVisiteDto>().ReverseMap();
        CreateMap<VisiteDto, VisiteViewModel>().ReverseMap();
        CreateMap<CreateUpdateVisiteDto, CreateUpdateVisiteViewModel>().ReverseMap();


        // Produit mappings
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductDto, ProductViewModel>().ReverseMap();
        CreateMap<Product, CreateUpdateProductDto>().ReverseMap();
        CreateMap<CreateUpdateProductViewModel, CreateUpdateProductDto>().ReverseMap();
        CreateMap<ProductDto, CategoryProductsViewModel>().ReverseMap();

        // Fournisseur mappings
        CreateMap<Fournisseur, FournisseurDTO>().ReverseMap();
        CreateMap<FournisseurDTO, FournisseurViewModel>().ReverseMap();

        // Vente mappings
        CreateMap<Vente, VenteDto>().ReverseMap();
        CreateMap<Vente, CreateUpdateVenteDto>().ReverseMap();
        CreateMap<CreateUpdateVenteDto, CreateUpdateVenteViewModel>().ReverseMap();
        CreateMap<VenteDto, VenteViewModel>().ReverseMap();

        // Achat mappings

        // Category mappings
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
        CreateMap<CategoryDto, CreateCategoriesViewModel>().ReverseMap();

        // User mappings
        CreateMap<SignUpUser, SignUpUserDto>().ReverseMap();
        CreateMap<SignInUser, SignInUserDto>().ReverseMap();
        CreateMap<SignUpUserDto, RegisterViewModel>().ReverseMap();
        CreateMap<SignUpUserDto, SignInViewModel>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserDto, UserViewModel>().ReverseMap();

        CreateMap<AchatCreateUpdateDTO, CreateUpdateAchatViewModel>()
        .ReverseMap(); // Enable reverse mapping

        // Mapping for CreateAchatDto and Achat
        CreateMap<AchatCreateUpdateDTO, Achat>()
        .ReverseMap(); // Enable reverse mapping

        // Mapping for Achat and AchatDto
        CreateMap<Achat, AchatDto>()
        .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.AchatProducts.Select(op => op.ProductId).ToList()))
        .ReverseMap().ForMember(dest => dest.AchatProducts, opt => opt.Ignore());

        // Enable reverse mapping

        CreateMap<AchatViewModel, AchatDto>()
         .ReverseMap(); // Enable reverse mapping
                        // Facture mappings
        CreateMap<Facture, FactureDTO>()
        .ReverseMap();

        CreateMap<FactureDTO, CreateFactureViewModel>().ReverseMap();
        CreateMap<FactureDTO, FactureViewModel>().ReverseMap();
        // Order mappings
        CreateMap<Order, OrderDto>()
           .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.OrderProducts.Select(op => op.ProductId).ToList()))
           .ReverseMap()
           .ForMember(dest => dest.OrderProducts, opt => opt.Ignore()); // Ignoring OrderProducts here, handle it separately if needed

        CreateMap<CreateUpdateOrderDto, Order>()
            .ReverseMap();
        CreateMap<OrderDto, OrderViewModel>().ReverseMap();
        CreateMap<CreateUpdateOrderViewModel, CreateUpdateOrderDto>().ReverseMap();

        // Caisse mappings
        CreateMap<Caisse, CaisseDTO>().ReverseMap();
        // Stock mappings

    }
}
