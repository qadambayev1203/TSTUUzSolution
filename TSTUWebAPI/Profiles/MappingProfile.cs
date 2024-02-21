using AutoMapper;
using Entities.DTO;
using Entities.DTO.DepartamentDetailsDTOS;
using Entities.DTO.DepartamentDTOS;
using Entities.DTO.DepartamentTypeDTOS;
using Entities.DTO.FilesDTOS;
using Entities.DTO.GenderDTOS;
using Entities.DTO.LanguageDTOS;
using Entities.DTO.PageDTOS;
using Entities.DTO.PersonDTOS;
using Entities.DTO.SiteDetailDTOS;
using Entities.DTO.SiteDTOS;
using Entities.DTO.SiteTypeDTOS;
using Entities.DTO.StatusDTOS;
using Entities.DTO.UserCrudDTOS;
using Entities.DTO.UserTypeDTOS;
using Entities.Model;
using Entities.Model.DepartamentDetailsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonModel;
using Entities.Model.SiteDetailsModel;
using Entities.Model.SitesModel;
using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;

namespace TSTUWebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();



            //Files DTOS
            CreateMap<FilesCreatedDTO, Files>();
            CreateMap<FilesUpdatedDTO, Files>();
            CreateMap<Files, FilesReadedDTO>();

            CreateMap<FilesTranslationCreatedDTO, FilesTranslation>();
            CreateMap<FilesTranslationUpdatedDTO, FilesTranslation>();
            CreateMap<FilesTranslation, FilesTranslationReadedDTO>();


            //Gender DTOS
            CreateMap<GenderCreatedDTO, Gender>();
            CreateMap<GenderUpdatedDTO, Gender>();
            CreateMap<Gender, GenderReadedDTO>();



            CreateMap<GenderTranslationCreatedDTO, GenderTranslation>();
            CreateMap<GenderTranslationUpdatedDTO, GenderTranslation>();
            CreateMap<GenderTranslation, GenderTranslationReadedDTO>();


            //Language DTOS
            CreateMap<LanguageCreatedDTO, Language>();
            CreateMap<LanguageUpdatedDTO, Language>();
            CreateMap<Language, LanguageReadedDTO>();


            //Person DTOS
            CreateMap<PersonCreatedDTO, Person>();
            CreateMap<PersonUpdatedDTO, Person>();
            CreateMap<Person, PersonReadedDTO>();


            CreateMap<PersonTranslationCreatedDTO, PersonTranslation>();
            CreateMap<PersonTranslationUpdatedDTO, PersonTranslation>();
            CreateMap<PersonTranslation, PersonTranslationReadedDTO>();

            //Status DTOS
            CreateMap<StatusCreatedDTO, Status>();
            CreateMap<StatusUpdatedDTO, Status>();
            CreateMap<Status, StatusReadedDTO>();


            CreateMap<StatusTranslationCreatedDTO, StatusTranslation>();
            CreateMap<StatusTranslationUpdatedDTO, StatusTranslation>();
            CreateMap<StatusTranslation, StatusTranslationReadedDTO>();

            //User CRUD DTOS
            CreateMap<UserCrudCreatedDTO, User>();
            CreateMap<UserCrudUpdatedDTO, User>();
            CreateMap<User, UserCrudReadedDTO>();

            //UserType DTOS
            CreateMap<UserTypeCreatedDTO, UserType>();
            CreateMap<UserTypeUpdatedDTO, UserType>();
            CreateMap<UserType, UserTypeReadedDTO>();


            CreateMap<UserTypeTranslationCreatedDTO, UserTypeTranslation>();
            CreateMap<UserTypeTranslationUpdatedDTO, UserTypeTranslation>();
            CreateMap<UserTypeTranslation, UserTypeTranslationReadedDTO>();


            //DepartamentDetail DTOS
            CreateMap<DepartamentDetailCreatedDTO, DepartamentDetail>();
            CreateMap<DepartamentDetailUpdatedDTO, DepartamentDetail>();
            CreateMap<DepartamentDetail, DepartamentDetailReadedDTO>();


            CreateMap<DepartamentDetailTranslationCreatedDTO, DepartamentDetailTranslation>();
            CreateMap<DepartamentDetailTranslationUpdatedDTO, DepartamentDetailTranslation>();
            CreateMap<DepartamentDetailTranslation, DepartamentDetailTranslationReadedDTO>();


            //Departament DTOS
            CreateMap<DepartamentCreatedDTO, Departament>();
            CreateMap<DepartamentUpdatedDTO, Departament>();
            CreateMap<Departament, DepartamentReadedDTO>();


            CreateMap<DepartamentTranslationCreatedDTO, DepartamentTranslation>();
            CreateMap<DepartamentTranslationUpdatedDTO, DepartamentTranslation>();
            CreateMap<DepartamentTranslation, DepartamentTranslationReadedDTO>();


            //DepartamentType DTOS
            CreateMap<DepartamentTypeCreatedDTO, DepartamentType>();
            CreateMap<DepartamentTypeUpdatedDTO, DepartamentType>();
            CreateMap<DepartamentType, DepartamentTypeReadedDTO>();


            CreateMap<DepartamentTypeTranslationCreatedDTO, DepartamentTypeTranslation>();
            CreateMap<DepartamentTypeTranslationUpdatedDTO, DepartamentTypeTranslation>();
            CreateMap<DepartamentTypeTranslation, DepartamentTypeTranslationReadedDTO>();


            //Page DTOS
            CreateMap<PageCreatedDTO, Pages>();
            CreateMap<PageUpdatedDTO, Pages>();
            CreateMap<Pages, PageReadedDTO>();


            CreateMap<PageTranslationCreatedDTO, PageTranslation>();
            CreateMap<PageTranslationUpdatedDTO, PageTranslation>();
            CreateMap<PageTranslation, PageTranslationReadedDTO>();


            //Site DTOS
            CreateMap<SiteCreatedDTO, Site>();
            CreateMap<SiteUpdatedDTO, Site>();
            CreateMap<Site, SiteReadedDTO>();


            CreateMap<SiteTranslationCreatedDTO, SiteTranslation>();
            CreateMap<SiteTranslationUpdatedDTO, SiteTranslation>();
            CreateMap<SiteTranslation, SiteTranslationReadedDTO>();




            //SiteDetail DTOS
            CreateMap<SiteDetailCreatedDTO, SiteDetail>();
            CreateMap<SiteDetailUpdatedDTO, SiteDetail>();
            CreateMap<SiteDetail, SiteDetailReadedDTO>();


            CreateMap<SiteDetailTranslationCreatedDTO, SiteDetailTranslation>();
            CreateMap<SiteDetailTranslationUpdatedDTO, SiteDetailTranslation>();
            CreateMap<SiteDetailTranslation, SiteDetailTranslationReadedDTO>();



            //SiteType DTOS
            CreateMap<SiteTypeCreatedDTO, SiteType>();
            CreateMap<SiteTypeUpdatedDTO, SiteType>();
            CreateMap<SiteType, SiteTypeReadedDTO>();


            CreateMap<SiteTypeTranslationCreatedDTO, SiteTypeTranslation>();
            CreateMap<SiteTypeTranslationUpdatedDTO, SiteTypeTranslation>();
            CreateMap<SiteTypeTranslation, SiteTypeTranslationReadedDTO>();
        }
    }
}
