using AutoMapper;
using Entities.DTO;
using Entities.DTO.FilesDTOS;
using Entities.DTO.GenderDTOS;
using Entities.DTO.LanguageDTOS;
using Entities.Model;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PersonModel;
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
        }
    }
}
