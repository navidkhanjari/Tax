using AutoMapper;
using CoreLayer.DTOs.AboutUs;
using CoreLayer.DTOs.Comments;
using CoreLayer.DTOs.ContactUs;
using CoreLayer.DTOs.FAQs;
using CoreLayer.DTOs.Messages;
using CoreLayer.DTOs.Posts;
using CoreLayer.DTOs.Services;
using CoreLayer.DTOs.Sliders;
using DataLayer.Entities.AboutUs;
using DataLayer.Entities.Comments;
using DataLayer.Entities.ContactUs;
using DataLayer.Entities.FAQ;
using DataLayer.Entities.Messages;
using DataLayer.Entities.Posts;
using DataLayer.Entities.Services;
using DataLayer.Entities.Sliders;

namespace CoreLayer.Mappers
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<AboutUs, AboutUsDTO>().ReverseMap();
			CreateMap<AboutUs, UpdateAboutUsDTO>().ReverseMap();

			CreateMap<ContactUs, UpdateContactUsDTO>().ReverseMap();
			CreateMap<ContactUs, ContactUsDTO>().ReverseMap();

			CreateMap<Comment, CommentsDTO>().ReverseMap();
			CreateMap<CreateCommentDTO, Comment>().ReverseMap();
			CreateMap<UpdateCommentDTO, Comment>().ReverseMap();

			CreateMap<FAQs, FAQsDTO>().ReverseMap();
			CreateMap<CreateFAQDTO, FAQs>().ReverseMap();
			CreateMap<UpdateFAQDTO, FAQs>().ReverseMap();

			CreateMap<Message, MessagesDTO>().ReverseMap();
			CreateMap<CreateMessageDTO, Message>().ReverseMap();

			CreateMap<Post, PostDTO>().ReverseMap();
			CreateMap<CreatePostDTO, Post>().ReverseMap();
			CreateMap<UpdatePostDTO, Post>().ReverseMap();

			CreateMap<Service, ServiceDTO>().ReverseMap();
			CreateMap<CreateServiceDTO, Service>().ReverseMap();
			CreateMap<UpdateServiceDTO, Service>().ReverseMap();

			CreateMap<Slider, SliderDTO>().ReverseMap();
			CreateMap<CreateSliderDTO, Slider>().ReverseMap();
			CreateMap<UpdateSliderDTO, Slider>().ReverseMap();
		}
	}
}
