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
			CreateMap<AboutUs, UpdateAboutUsDTO>();

			CreateMap<ContactUs, UpdateContactUsDTO>();
			CreateMap<ContactUs, ContactUsDTO>().ReverseMap();

			CreateMap<Comment, CommentsDTO>().ReverseMap();
			CreateMap<CreateCommentDTO, Comment>();
			CreateMap<UpdateCommentDTO, Comment>();

			CreateMap<FAQs, FAQsDTO>().ReverseMap();
			CreateMap<CreateFAQDTO, FAQs>();
			CreateMap<UpdateFAQDTO, FAQs>();

			CreateMap<Message, MessagesDTO>().ReverseMap();
			CreateMap<CreateMessageDTO, FAQs>();
			CreateMap<UpdateMessageDTO, FAQs>();

			CreateMap<Post, PostDTO>().ReverseMap();
			CreateMap<CreatePostDTO, Post>();
			CreateMap<UpdatePostDTO, Post>();

			CreateMap<Service, ServiceDTO>().ReverseMap();
			CreateMap<CreateServiceDTO, Service>();
			CreateMap<UpdateServiceDTO, Service>();

			CreateMap<Slider, SliderDTO>().ReverseMap();
			CreateMap<CreateSliderDTO, Slider>();
			CreateMap<UpdateSliderDTO, Slider>();
		}
	}
}
