using AutoMapper;
using Entities.DTO;
using Entities.DTO.AppealsToRectorDTOS;
using Entities.DTO.BlogsCategoryDTOS;
using Entities.DTO.BlogsDTOS;
using Entities.DTO.CountrysDTOS;
using Entities.DTO.DepartamentDetailsDTOS;
using Entities.DTO.DepartamentDTOS;
using Entities.DTO.DepartamentTypeDTOS;
using Entities.DTO.DistrictsDTOS;
using Entities.DTO.EmploymentsDTOS;
using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.FilesDTOS;
using Entities.DTO.GenderDTOS;
using Entities.DTO.LanguageDTOS;
using Entities.DTO.MenuDTOS;
using Entities.DTO.MenuTypesDTOS;
using Entities.DTO.NeighborhoodsDTOS;
using Entities.DTO.PageDTOS;
using Entities.DTO.PersonDataDTOS;
using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentDetailConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuTypesConfDTO;
using Entities.DTO.ReadedDTOSConfigurations.NeighborhoodConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteDeatilConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Entities.DTO.SiteDetailDTOS;
using Entities.DTO.SiteDTOS;
using Entities.DTO.SiteTypeDTOS;
using Entities.DTO.StatusDTOS;
using Entities.DTO.TerritoriesDTOS;
using Entities.DTO.TokensDTOS;
using Entities.DTO.UserCrudDTOS;
using Entities.DTO.UserTypeDTOS;
using Entities.Model;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.BlogsCategoryModel;
using Entities.Model.BlogsModel;
using Entities.Model.CountrysModel;
using Entities.Model.DepartamentDetailsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.DistrictsModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.MenuModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.NeighborhoodsModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonDataModel;
using Entities.Model.PersonModel;
using Entities.Model.SiteDetailsModel;
using Entities.Model.SitesModel;
using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using Entities.Model.TerritoriesModel;
using Entities.Model.TokensModel;
using Entities.Model.EmploymentModel;
using Entities.Model.EmployeeTypesModel;
using Entities.DTO.InteractiveServicesDTOS;
using Entities.Model.InteractiveServicesModel;
using Entities.DTO.StatisticalNumbersDTOS;
using Entities.Model.StatisticalNumbersModel;
using Entities.DTO.UserProfilDTOS;
using Entities.DTO.AppealsToEmployeeDTOS;
using Entities.Model.AppealToEmployeeModel;
using Entities.Model.DocumentTeacher110Model;
using Entities.DTO.DocumentTeacher110DTOS;
using Newtonsoft.Json;
using Entities.DTO.DocumentTeacher110SetDTOS;
using Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;
using Entities.Model.PersonDataModel.PersonScientificActivityModel;
using Entities.DTO.PersonDataDTOS.PersonBlogDTOS;
using Entities.Model.PersonDataModel.PersonBlogModel;
using Entities.DTO.PersonDataDTOS.PersonPortfolioDTOS;
using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.DTO.PersonDataDTOS.PersonExperienceDTOS;
using Entities.Model.PersonDataModel.PersonExperienceModel;
using Entities.DTO.RectorGivenDTOS;

namespace TSTUWebAPI.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User DTOS
        CreateMap<User, UserDTO>();
        #endregion

        #region Files DTOS
        CreateMap<FilesCreatedDTO, Files>();
        CreateMap<FilesUpdatedDTO, Files>();
        CreateMap<Files, FilesReadedDTO>();
        CreateMap<Files, FileConfReadedDTO>();
        CreateMap<Files, FileSelectDTO>();

        CreateMap<FilesTranslationCreatedDTO, FilesTranslation>();
        CreateMap<FilesTranslationUpdatedDTO, FilesTranslation>();
        CreateMap<FilesTranslation, FilesTranslationReadedDTO>();
        CreateMap<FilesTranslation, FileTranslationConfReadedDTO>();
        CreateMap<FilesTranslation, FileTranslationSelectDTO>();


        #endregion

        #region Gender DTOS
        CreateMap<GenderCreatedDTO, Gender>();
        CreateMap<GenderUpdatedDTO, Gender>();
        CreateMap<Gender, GenderReadedDTO>();
        CreateMap<Gender, GenderReadedSiteDTO>();
        CreateMap<Gender, GenderConfReadedDTO>();



        CreateMap<GenderTranslationCreatedDTO, GenderTranslation>();
        CreateMap<GenderTranslationUpdatedDTO, GenderTranslation>();
        CreateMap<GenderTranslation, GenderTranslationReadedDTO>();
        CreateMap<GenderTranslation, GenderTranslationReadedSiteDTO>();
        CreateMap<GenderTranslation, GenderTranslationConfReadedDTO>();


        #endregion

        #region Language DTOS
        CreateMap<LanguageCreatedDTO, Language>();
        CreateMap<LanguageUpdatedDTO, Language>();
        CreateMap<Language, LanguageReadedDTO>();
        CreateMap<Language, LanguageReadedSiteDTO>();
        CreateMap<Language, LanguageConfReadedDTO>();


        #endregion

        #region Person DTOS
        CreateMap<PersonCreatedDTO, Person>();
        CreateMap<PersonCreatedDataDTO, Person>();
        CreateMap<PersonUpdatedDTO, Person>();
        CreateMap<PersonUpdatedDataDTO, Person>();
        CreateMap<PersonRectorUpdatedDataDTO, Person>();
        CreateMap<Person, PersonReadedDTO>();
        CreateMap<Person, PersonUserDTO>();
        CreateMap<Person, PersonfioDTO>();
        CreateMap<Person, PersonReadedSiteDTO>();
        CreateMap<Person, PersonConfReadedDTO>();
        CreateMap<Person, PersonReadedConfigurDTO>();
        CreateMap<Person, PesonConfDTO>();
        CreateMap<Person, PersonRectorConfReadedDTOAll>();
        CreateMap<Person, PersonRectorConfReadedDTO>();
        CreateMap<Person, PesonSiteConfDTO>();
        CreateMap<Person, PersonUserReadedDTO>();
        CreateMap<PersonUserProfilUpdatedDTO, Person>();


        CreateMap<PersonTranslationCreatedDTO, PersonTranslation>();
        CreateMap<PersonTranslationCreatedDataDTO, PersonTranslation>();
        CreateMap<PersonTranslationUpdatedDTO, PersonTranslation>();
        CreateMap<PersonTranslationUpdatedDataDTO, PersonTranslation>();
        CreateMap<PersonTranslationRectorUpdatedDataDTO, PersonTranslation>();
        CreateMap<PersonTranslation, PersonfioTranslationDTO>();
        CreateMap<PersonTranslation, PersonTranslationReadedDTO>();
        CreateMap<PersonTranslation, PersonTranslationReadedSiteDTO>();
        CreateMap<PersonTranslation, PesonTranslationSiteConfDTO>();
        CreateMap<PersonTranslation, PesonTranslationRectorSiteConfDTO>();


        #endregion

        #region PersonData DTOS
        CreateMap<PersonDataCreatedDTO, PersonData>();
        CreateMap<PersonDataUpdatedDTO, PersonData>();
        CreateMap<PersonDataProfileUpdatedDTO, PersonData>();
        CreateMap<PersonData, PersonDataReadedEmployeeTypeDTO>();
        CreateMap<PersonData, PersonDataSearchDTO>();
        CreateMap<PersonData, PersonDataReadedEmployeeTypeSiteDTO>();
        CreateMap<PersonData, PersonDataReadedDTO>();
        CreateMap<PersonData, PersonDataReadedSiteDTO>();
        CreateMap<PersonData, PesonDataConfDTO>();


        CreateMap<PersonDataTranslationCreatedDTO, PersonDataTranslation>();
        CreateMap<PersonDataTranslationUpdatedDTO, PersonDataTranslation>();
        CreateMap<PersonDataTranslationProfileUpdatedDTO, PersonDataTranslation>();
        CreateMap<PersonDataTranslation, PersonDataTranslationSearchDTO>();
        CreateMap<PersonDataTranslation, PersonDataTranslationReadedDTO>();
        CreateMap<PersonDataTranslation, PersonDataTranslationReadedEmployeeTypeDTO>();
        CreateMap<PersonDataTranslation, PersonDataTranslationReadedEmployeeTypeSiteDTO>();
        CreateMap<PersonDataTranslation, PersonDataTranslationReadedSiteDTO>();

        #region PersonScientificActivity DTOS

        CreateMap<PersonScientificActivityCreatedDTO, PersonScientificActivity>();
        CreateMap<PersonBlogCreatedAdminDTO, PersonScientificActivity>();
        CreateMap<PersonScientificActivityUpdatedAdminDTO, PersonScientificActivity>();
        CreateMap<PersonScientificActivityUpdatedDTO, PersonScientificActivity>();
        CreateMap<PersonScientificActivity, PersonScientificActivityReadedDTO>();
        CreateMap<PersonScientificActivity, PersonScientificActivityReadedSiteDTO>();

        CreateMap<PersonScientificActivityTranslationCreatedDTO, PersonScientificActivityTranslation>();
        CreateMap<PersonScientificActivityTranslationCreatedAdminDTO, PersonScientificActivityTranslation>();
        CreateMap<PersonScientificActivityTranslationUpdatedAdminDTO, PersonScientificActivityTranslation>();
        CreateMap<PersonScientificActivityTranslationUpdatedDTO, PersonScientificActivityTranslation>();
        CreateMap<PersonScientificActivityTranslation, PersonScientificActivityTranslationReadedDTO>();
        CreateMap<PersonScientificActivityTranslation, PersonScientificActivityTranslationReadedSiteDTO>();

        #endregion

        #region PersonBlog DTOS

        CreateMap<PersonBlogCreatedDTO, PersonBlog>();
        CreateMap<PersonBlogCreatedAdminDTO, PersonBlog>();
        CreateMap<PersonBlogUpdatedAdminDTO, PersonBlog>();
        CreateMap<PersonBlogUpdatedDTO, PersonBlog>();
        CreateMap<PersonBlog, PersonBlogReadedDTO>();
        CreateMap<PersonBlog, PersonBlogReadedSiteDTO>();

        CreateMap<PersonBlogTranslationCreatedDTO, PersonBlogTranslation>();
        CreateMap<PersonBlogTranslationCreatedAdminDTO, PersonBlogTranslation>();
        CreateMap<PersonBlogTranslationUpdatedAdminDTO, PersonBlogTranslation>();
        CreateMap<PersonBlogTranslationUpdatedDTO, PersonBlogTranslation>();
        CreateMap<PersonBlogTranslation, PersonBlogTranslationReadedDTO>();
        CreateMap<PersonBlogTranslation, PersonBlogTranslationReadedSiteDTO>();

        #endregion

        #region PersonPortfolio DTOS

        CreateMap<PersonPortfolioCreatedDTO, PersonPortfolio>();
        CreateMap<PersonPortfolioCreatedAdminDTO, PersonPortfolio>();
        CreateMap<PersonPortfolioUpdatedAdminDTO, PersonPortfolio>();
        CreateMap<PersonPortfolioUpdatedDTO, PersonPortfolio>();
        CreateMap<PersonPortfolio, PersonPortfolioReadedDTO>();
        CreateMap<PersonPortfolio, PersonPortfolioReadedSiteDTO>();

        CreateMap<PersonPortfolioTranslationCreatedDTO, PersonPortfolioTranslation>();
        CreateMap<PersonPortfolioTranslationCreatedAdminDTO, PersonPortfolioTranslation>();
        CreateMap<PersonPortfolioTranslationUpdatedAdminDTO, PersonPortfolioTranslation>();
        CreateMap<PersonPortfolioTranslationUpdatedDTO, PersonPortfolioTranslation>();
        CreateMap<PersonPortfolioTranslation, PersonPortfolioTranslationReadedDTO>();
        CreateMap<PersonPortfolioTranslation, PersonPortfolioTranslationReadedSiteDTO>();

        #endregion

        #region PersonExperience DTOS

        CreateMap<PersonExperienceCreatedDTO, PersonExperience>();
        CreateMap<PersonExperienceCreatedAdminDTO, PersonExperience>();
        CreateMap<PersonExperienceUpdatedAdminDTO, PersonExperience>();
        CreateMap<PersonExperienceUpdatedDTO, PersonExperience>();
        CreateMap<PersonExperience, PersonExperienceReadedDTO>();
        CreateMap<PersonExperience, PersonExperienceReadedSiteDTO>();

        CreateMap<PersonExperienceTranslationCreatedDTO, PersonExperienceTranslation>();
        CreateMap<PersonExperienceTranslationCreatedAdminDTO, PersonExperienceTranslation>();
        CreateMap<PersonExperienceTranslationUpdatedAdminDTO, PersonExperienceTranslation>();
        CreateMap<PersonExperienceTranslationUpdatedDTO, PersonExperienceTranslation>();
        CreateMap<PersonExperienceTranslation, PersonExperienceTranslationReadedDTO>();
        CreateMap<PersonExperienceTranslation, PersonExperienceTranslationReadedSiteDTO>();

        #endregion

        #endregion

        #region Status DTOS
        CreateMap<StatusCreatedDTO, Status>();
        CreateMap<StatusUpdatedDTO, Status>();
        CreateMap<Status, StatusReadedDTO>();
        CreateMap<Status, StatusReadedSiteDTO>();
        CreateMap<Status, StatusConfReadedDTO>();



        CreateMap<StatusTranslationCreatedDTO, StatusTranslation>();
        CreateMap<StatusTranslationUpdatedDTO, StatusTranslation>();
        CreateMap<StatusTranslation, StatusTranslationReadedDTO>();
        CreateMap<StatusTranslation, StatusTranslationReadedSiteDTO>();
        CreateMap<StatusTranslation, StatusTranslationConfReadedDTO>();

        #endregion

        #region User CRUD DTOS
        CreateMap<UserCrudCreatedDTO, User>();
        CreateMap<UserCrudUpdatedDTO, User>();
        CreateMap<UserProfilUpdatedDTO, User>();
        CreateMap<User, UserCrudReadedDTO>();
        CreateMap<User, UserConfReadedDTO>();
        CreateMap<User, UserFIODTO>();

        #endregion

        #region UserType DTOS
        CreateMap<UserTypeCreatedDTO, UserType>();
        CreateMap<UserTypeUpdatedDTO, UserType>();
        CreateMap<UserType, UserTypeReadedDTO>();
        CreateMap<UserType, UserTypeReadedSiteDTO>();
        CreateMap<UserType, UserTypeConfReadedDTO>();


        CreateMap<UserTypeTranslationCreatedDTO, UserTypeTranslation>();
        CreateMap<UserTypeTranslationUpdatedDTO, UserTypeTranslation>();
        CreateMap<UserTypeTranslation, UserTypeTranslationReadedDTO>();
        CreateMap<UserTypeTranslation, UserTypeTranslationReadedSiteDTO>();


        #endregion

        #region DepartamentDetail DTOS
        CreateMap<DepartamentDetailCreatedDTO, DepartamentDetail>();
        CreateMap<DepartamentDetailUpdatedDTO, DepartamentDetail>();
        CreateMap<DepartamentDetail, DepartamentDetailReadedDTO>();
        CreateMap<DepartamentDetail, DepartamentDetailReadedSiteDTO>();
        CreateMap<DepartamentDetail, DepartamentDetailConfRededDTO>();


        CreateMap<DepartamentDetailTranslationCreatedDTO, DepartamentDetailTranslation>();
        CreateMap<DepartamentDetailTranslationUpdatedDTO, DepartamentDetailTranslation>();
        CreateMap<DepartamentDetailTranslation, DepartamentDetailTranslationReadedDTO>();
        CreateMap<DepartamentDetailTranslation, DepartamentDetailTranslationReadedSiteDTO>();


        #endregion

        #region Departament DTOS
        CreateMap<DepartamentCreatedDTO, Departament>();
        CreateMap<DepartamentUpdatedDTO, Departament>();
        CreateMap<DepartamentUpdatedHeadDepDTO, Departament>();
        CreateMap<Departament, DepartamentReadedDTO>();
        CreateMap<Departament, DepartamentSelectedReadedDTO>();
        CreateMap<Departament, DepartamentReadedTypedDTO>();
        CreateMap<Departament, DepartamentReadedHeadDepDTO>();
        CreateMap<Departament, DepartamentSearchDTO>();
        CreateMap<Departament, DepartamentReadedSiteDTO>();
        CreateMap<Departament, DepartamentChildReadedSiteDTO>();
        CreateMap<Departament, DepartamentConfReadedDTO>();
        CreateMap<Departament, DepartamentConfReadedFacultyDTO>();
        CreateMap<Departament, DepartamentStructureReadedDTO>();


        CreateMap<DepartamentTranslationCreatedDTO, DepartamentTranslation>();
        CreateMap<DepartamentTranslationUpdatedDTO, DepartamentTranslation>();
        CreateMap<DepartamentTranslationUpdatedHeadDepDTO, DepartamentTranslation>();
        CreateMap<DepartamentTranslation, DepartamentTranslationSearchDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationReadedDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationReadedHeadDepDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationSelectedReadedDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationReadedTypedDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationReadedSiteDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationReadedSiteFacultyDTO>();
        CreateMap<DepartamentTranslation, DepartamentChildTranslationReadedSiteDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationConfReadedDTO>();
        CreateMap<DepartamentTranslation, DepartamentTranslationStructureReadedDTO>();


        #endregion

        #region DepartamentType DTOS
        CreateMap<DepartamentTypeCreatedDTO, DepartamentType>();
        CreateMap<DepartamentTypeUpdatedDTO, DepartamentType>();
        CreateMap<DepartamentType, DepartamentTypeReadedDTO>();
        CreateMap<DepartamentType, DepartamentTypeReadedSiteDTO>();
        CreateMap<DepartamentType, DepartamentTypeConfReadedDTO>();


        CreateMap<DepartamentTypeTranslationCreatedDTO, DepartamentTypeTranslation>();
        CreateMap<DepartamentTypeTranslationUpdatedDTO, DepartamentTypeTranslation>();
        CreateMap<DepartamentTypeTranslation, DepartamentTypeTranslationReadedDTO>();
        CreateMap<DepartamentTypeTranslation, DepartamentTypeTranslationReadedSiteDTO>();
        CreateMap<DepartamentTypeTranslation, DepartamentTypeTranslationConfReadedDTO>();


        #endregion

        #region Page DTOS
        CreateMap<PageCreatedDTO, Pages>();
        CreateMap<PageUpdatedDTO, Pages>();
        CreateMap<Pages, PageSearchDTO>();
        CreateMap<Pages, PageReadedDTO>();
        CreateMap<Pages, PageReadedSelectDTO>();
        CreateMap<Pages, PageReadedSiteDTO>();
        CreateMap<Pages, PageConfReadDTO>();


        CreateMap<PageTranslationCreatedDTO, PageTranslation>();
        CreateMap<PageTranslationUpdatedDTO, PageTranslation>();
        CreateMap<PageTranslation, PageTranslationSearchDTO>();
        CreateMap<PageTranslation, PageTranslationConfReadedDTO>();
        CreateMap<PageTranslation, PageTranslationReadedDTO>();
        CreateMap<PageTranslation, PageTranslationReadedSelectDTO>();
        CreateMap<PageTranslation, PageTranslationReadedSiteDTO>();


        #endregion

        #region Site DTOS
        CreateMap<SiteCreatedDTO, Site>();
        CreateMap<SiteUpdatedDTO, Site>();
        CreateMap<Site, SiteReadedDTO>();
        CreateMap<Site, SiteReadedSiteDTO>();
        CreateMap<Site, SiteConfReadedDTO>();


        CreateMap<SiteTranslationCreatedDTO, SiteTranslation>();
        CreateMap<SiteTranslationUpdatedDTO, SiteTranslation>();
        CreateMap<SiteTranslation, SiteTranslationReadedDTO>();
        CreateMap<SiteTranslation, SiteTranslationReadedSiteDTO>();
        CreateMap<SiteTranslation, SiteTranslationConfReadedDTO>();




        #endregion

        #region SiteDetail DTOS
        CreateMap<SiteDetailCreatedDTO, SiteDetail>();
        CreateMap<SiteDetailUpdatedDTO, SiteDetail>();
        CreateMap<SiteDetail, SiteDetailReadedDTO>();
        CreateMap<SiteDetail, SiteDetailReadedSiteDTO>();
        CreateMap<SiteDetail, SiteDetailConfreadedDTO>();


        CreateMap<SiteDetailTranslationCreatedDTO, SiteDetailTranslation>();
        CreateMap<SiteDetailTranslationUpdatedDTO, SiteDetailTranslation>();
        CreateMap<SiteDetailTranslation, SiteDetailTranslationReadedDTO>();
        CreateMap<SiteDetailTranslation, SiteDetailTranslationReadedSiteDTO>();



        #endregion

        #region SiteType DTOS
        CreateMap<SiteTypeCreatedDTO, SiteType>();
        CreateMap<SiteTypeUpdatedDTO, SiteType>();
        CreateMap<SiteType, SiteTypeReadedDTO>();
        CreateMap<SiteType, SiteTypeReadedSiteDTO>();
        CreateMap<SiteType, SiteTypeConfReadedDTO>();


        CreateMap<SiteTypeTranslationCreatedDTO, SiteTypeTranslation>();
        CreateMap<SiteTypeTranslationUpdatedDTO, SiteTypeTranslation>();
        CreateMap<SiteTypeTranslation, SiteTypeTranslationReadedDTO>();
        CreateMap<SiteTypeTranslation, SiteTypeTranslationReadedSiteDTO>();
        CreateMap<SiteTypeTranslation, SiteTypeTranslationConfDTO>();

        #endregion

        #region BlogCategory DTOS
        CreateMap<BlogCategoryCreatedDTO, BlogCategory>();
        CreateMap<BlogCategoryUpdatedDTO, BlogCategory>();
        CreateMap<BlogCategoryUpdatedModeratorDTO, BlogCategory>();
        CreateMap<BlogCategory, BlogCategoryReadedDTO>();
        CreateMap<BlogCategory, BlogCategoryReadedSiteDTO>();
        CreateMap<BlogCategory, BlogCategoryReadedConfDTO>();


        CreateMap<BlogCategoryTranslationCreatedDTO, BlogCategoryTranslation>();
        CreateMap<BlogCategoryTranslationUpdatedDTO, BlogCategoryTranslation>();
        CreateMap<BlogCategoryTranslationUpdatedModeratorDTO, BlogCategoryTranslation>();
        CreateMap<BlogCategoryTranslation, BlogTranslationConfReadedDTO>();
        CreateMap<BlogCategoryTranslation, BlogCategoryTranslationReadedDTO>();
        CreateMap<BlogCategoryTranslation, BlogCategoryTranslationReadedSiteDTO>();
        CreateMap<BlogCategoryTranslation, BlogCategoryTranslationReadedConfDTO>();


        #endregion

        #region Blog DTOS
        CreateMap<BlogCreatedDTO, Blog>();
        CreateMap<BlogUpdatedDTO, Blog>();
        CreateMap<BlogUpdatedModeratorDTO, Blog>();
        CreateMap<Blog, BlogReadedDTO>();
        CreateMap<Blog, BlogSearchDTO>();
        CreateMap<Blog, BlogReadedSelectDTO>();
        CreateMap<Blog, BlogReadedSiteDTO>();
        CreateMap<Blog, BlogConfRededDTO>();


        CreateMap<BlogTranslationCreatedDTO, BlogTranslation>();
        CreateMap<BlogTranslationUpdatedDTO, BlogTranslation>();
        CreateMap<BlogTranslationUpdatedModeratorDTO, BlogTranslation>();
        CreateMap<BlogTranslation, BlogTranslationReadedDTO>();
        CreateMap<BlogTranslation, BlogTranslationSearchDTO>();
        CreateMap<BlogTranslation, BlogTranslationReadedSelectDTO>();
        CreateMap<BlogTranslation, BlogTranslationReadedSiteDTO>();



        #endregion

        #region Country DTOS
        CreateMap<CountryCreatedDTO, Country>();
        CreateMap<CountryUpdatedDTO, Country>();
        CreateMap<Country, CountryReadedDTO>();
        CreateMap<Country, CountryReadedSiteDTO>();
        CreateMap<Country, CountryReadedConfDTO>();


        CreateMap<CountryTranslationCreatedDTO, CountryTranslation>();
        CreateMap<CountryTranslationUpdatedDTO, CountryTranslation>();
        CreateMap<CountryTranslation, CountryTranslationReadedDTO>();
        CreateMap<CountryTranslation, CountryTranslationReadedSiteDTO>();
        CreateMap<CountryTranslation, CountryTranslationReadedConfDTO>();


        #endregion

        #region Territorie DTOS
        CreateMap<TerritorieCreatedDTO, Territorie>();
        CreateMap<TerritorieUpdatedDTO, Territorie>();
        CreateMap<Territorie, TerritorieReadedDTO>();
        CreateMap<Territorie, TerritorieReadedIdDTO>();
        CreateMap<Territorie, TerritorieReadedSiteDTO>();
        CreateMap<Territorie, TerritorieConfReadedDTO>();


        CreateMap<TerritorieTranslationCreatedDTO, TerritorieTranslation>();
        CreateMap<TerritorieTranslationUpdatedDTO, TerritorieTranslation>();
        CreateMap<TerritorieTranslation, TerritorieTranslationReadedDTO>();
        CreateMap<TerritorieTranslation, TerritorieTranslationReadedIdDTO>();
        CreateMap<TerritorieTranslation, TerritorieTranslationReadedSiteDTO>();
        CreateMap<TerritorieTranslation, TerritorieTranslationConfReadedDTO>();


        #endregion

        #region District DTOS
        CreateMap<DistrictCreatedDTO, District>();
        CreateMap<DistrictUpdatedDTO, District>();
        CreateMap<District, DistrictReadedDTO>();
        CreateMap<District, DistrictReadedIdDTO>();
        CreateMap<District, DistrictReadedSiteDTO>();
        CreateMap<District, DistrictConfReadedDTO>();


        CreateMap<DistrictTranslationCreatedDTO, DistrictTranslation>();
        CreateMap<DistrictTranslationUpdatedDTO, DistrictTranslation>();
        CreateMap<DistrictTranslation, DistrictTranslationReadedDTO>();
        CreateMap<DistrictTranslation, DistrictTranslationReadedIdDTO>();
        CreateMap<DistrictTranslation, DistrictTranslationReadedSiteDTO>();
        CreateMap<DistrictTranslation, DistrictTranslationConfReadedDTO>();



        #endregion

        #region Neighborhood DTOS
        CreateMap<NeighborhoodCreatedDTO, Neighborhood>();
        CreateMap<NeighborhoodUpdatedDTO, Neighborhood>();
        CreateMap<Neighborhood, NeighborhoodReadedDTO>();
        CreateMap<Neighborhood, NeighborhoodReadedIdDTO>();
        CreateMap<Neighborhood, NeighborhoodReadedSiteDTO>();
        CreateMap<Neighborhood, NeighborhoodConfReadedDTO>();


        CreateMap<NeighborhoodTranslationCreatedDTO, NeighborhoodTranslation>();
        CreateMap<NeighborhoodTranslationUpdatedDTO, NeighborhoodTranslation>();
        CreateMap<NeighborhoodTranslation, NeighborhoodTranslationReadedDTO>();
        CreateMap<NeighborhoodTranslation, NeighborhoodTranslationReadedIdDTO>();
        CreateMap<NeighborhoodTranslation, NeighborhoodTranslationReadedSiteDTO>();
        CreateMap<NeighborhoodTranslation, NeighborhoodTranslationConfReadedDTO>();



        #endregion

        #region Employment DTOS
        CreateMap<EmploymentCreatedDTO, Employment>();
        CreateMap<EmploymentUpdatedDTO, Employment>();
        CreateMap<Employment, EmploymentReadedDTO>();
        CreateMap<Employment, EmploymentReadedSiteDTO>();


        CreateMap<EmploymentTranslationCreatedDTO, EmploymentTranslation>();
        CreateMap<EmploymentTranslationUpdatedDTO, EmploymentTranslation>();
        CreateMap<EmploymentTranslation, EmploymentTranslationReadedDTO>();
        CreateMap<EmploymentTranslation, EmploymentTranslationReadedSiteDTO>();
        CreateMap<EmploymentTranslation, EmploymentTranslationConfRededDTO>();


        #endregion

        #region EmployeeType DTOS
        CreateMap<EmployeeTypeCreatedDTO, EmployeeType>();
        CreateMap<EmployeeTypeUpdatedDTO, EmployeeType>();
        CreateMap<EmployeeType, EmployeeTypeReadedDTO>();
        CreateMap<EmployeeType, EmployeeTypeReadedSiteDTO>();


        CreateMap<EmployeeTypeTranslationCreatedDTO, EmployeeTypeTranslation>();
        CreateMap<EmployeeTypeTranslationUpdatedDTO, EmployeeTypeTranslation>();
        CreateMap<EmployeeTypeTranslation, EmployeeTypeTranslationReadedDTO>();
        CreateMap<EmployeeTypeTranslation, EmployeeTypeTranslationReadedSiteDTO>();
        CreateMap<EmployeeTypeTranslation, EmployeeTypeTranslationConfReadedDTO>();


        #endregion

        #region AppealToRector DTOS
        CreateMap<AppealToRectorCreatedDTO, AppealToRector>();
        CreateMap<AppealToRectorUpdatedDTO, AppealToRector>();
        CreateMap<AppealToRector, AppealToRectorReadedDTO>();
        CreateMap<AppealToRector, AppealToRectorConfRededDTO>();
        CreateMap<AppealToRector, AppealEmailCheckStatusDTO>();


        CreateMap<AppealToRectorTranslationCreatedDTO, AppealToRectorTranslation>();
        CreateMap<AppealToRectorTranslationUpdatedDTO, AppealToRectorTranslation>();
        CreateMap<AppealToRectorTranslation, AppealToRectorTranslationReadedDTO>();
        CreateMap<AppealToRectorTranslation, AppealTranslationEmailCheckStatusDTO>();


        #endregion

        #region AppealToEmployee DTOS
        CreateMap<AppealToEmployeeCreatedDTO, AppealToEmployee>();
        CreateMap<AppealToEmployee, AppealToEmployeeReadedDTO>();
        CreateMap<AppealToEmployee, AppealToEmployeeReadedAdminDTO>();


        CreateMap<AppealToEmployeeTranslationCreatedDTO, AppealToEmployeeTranslation>();
        CreateMap<AppealToEmployeeTranslation, AppealToEmployeeTranslationReadedDTO>();
        CreateMap<AppealToEmployeeTranslation, AppealToEmployeeTranslationReadedAdminDTO>();

        #endregion

        #region MenuType DTOS
        CreateMap<MenuTypeCreatedDTO, MenuType>();
        CreateMap<MenuTypeUpdatedDTO, MenuType>();
        CreateMap<MenuType, MenuTypeReadedDTO>();
        CreateMap<MenuType, MenuTypeReadedSiteDTO>();
        CreateMap<MenuType, MenuTypeConfReadedDTO>();
        CreateMap<MenuType, AppealEmailCheckStatusDTO>();


        CreateMap<MenuTypeTranslationCreatedDTO, MenuTypeTranslation>();
        CreateMap<MenuTypeTranslationUpdatedDTO, MenuTypeTranslation>();
        CreateMap<MenuTypeTranslation, MenuTypeTranslationReadedDTO>();
        CreateMap<MenuTypeTranslation, MenuTypeTranslationReadedSiteDTO>();
        CreateMap<MenuTypeTranslation, MenuTypeTranslationConfReadedDTO>();

        #endregion

        #region Menu DTOS
        CreateMap<MenuCreatedDTO, Menu>();
        CreateMap<MenuUpdatedDTO, Menu>();
        CreateMap<Menu, MenuReadedDTO>();
        CreateMap<Menu, MenuReadedSiteDTO>();
        CreateMap<Menu, MenuConfReadedDTO>();


        CreateMap<MenuTranslationCreatedDTO, MenuTranslation>();
        CreateMap<MenuTranslationUpdatedDTO, MenuTranslation>();
        CreateMap<MenuTranslation, MenuTranslationReadedDTO>();
        CreateMap<MenuTranslation, MenuTranslationReadedSiteDTO>();



        #endregion

        #region Tokens DTOS
        CreateMap<TokensCreatedDTO, Tokens>();
        CreateMap<TokensUpdatedDTO, Tokens>();
        CreateMap<Tokens, TokensReadedDTO>();
        CreateMap<Tokens, TokensReadedSiteDTO>();


        #endregion

        #region InteractiveServices DTOS
        CreateMap<InteractiveServicesCreatedDTO, InteractiveServices>();
        CreateMap<InteractiveServicesUpdatedDTO, InteractiveServices>();
        CreateMap<InteractiveServices, InteractiveServicesReadedDTO>();
        CreateMap<InteractiveServices, InteractiveServicesReadedConfDTO>();
        CreateMap<InteractiveServices, InteractiveServicesReadedSiteDTO>();


        CreateMap<InteractiveServicesTranslationCreatedDTO, InteractiveServicesTranslation>();
        CreateMap<InteractiveServicesTranslationUpdatedDTO, InteractiveServicesTranslation>();
        CreateMap<InteractiveServicesTranslation, InteractiveServicesTranslationReadedDTO>();
        CreateMap<InteractiveServicesTranslation, InteractiveServicesTranslationReadedSiteDTO>();
        CreateMap<InteractiveServicesTranslation, InteractiveServicesTranslationConfReadedDTO>();
        #endregion

        #region StatisticalNumbers DTOS
        CreateMap<StatisticalNumbersCreatedDTO, StatisticalNumbers>();
        CreateMap<StatisticalNumbersUpdatedDTO, StatisticalNumbers>();
        CreateMap<StatisticalNumbers, StatisticalNumbersReadedDTO>();
        CreateMap<StatisticalNumbers, StatisticalNumbersReadedConfDTO>();
        CreateMap<StatisticalNumbers, StatisticalNumbersReadedSiteDTO>();


        CreateMap<StatisticalNumbersTranslationCreatedDTO, StatisticalNumbersTranslation>();
        CreateMap<StatisticalNumbersTranslationUpdatedDTO, StatisticalNumbersTranslation>();
        CreateMap<StatisticalNumbersTranslation, StatisticalNumbersTranslationReadedDTO>();
        CreateMap<StatisticalNumbersTranslation, StatisticalNumbersTranslationReadedSiteDTO>();
        CreateMap<StatisticalNumbersTranslation, StatisticalNumbersTranslationConfReadedDTO>();
        #endregion

        #region DocumentTeacher110 DTOS
        CreateMap<DocumentTeacher110UpdatedDTO, DocumentTeacher110>();
        CreateMap<DocumentTeacher110, DocumentTeacher110ReadedDTO>();
        CreateMap<DocumentTeacher110, DocumentTeacher110SelectDTO>();
        CreateMap<DocumentTeacher110, DocumentTeacher110AdminReadedDTO>();
        CreateMap<DocumentTeacher110CreatedDTO, DocumentTeacher110>()
                                                         .ForMember(dest => dest.document_sequence_string, opt =>
                                                          opt.MapFrom(src => src.document_sequence != null ? JsonConvert
                                                          .SerializeObject(src.document_sequence.Select(ds => new DocumentSequenceItemDTO { sequence_number = ds.sequence_number, profil_user_id = ds.profil_user_id })
                                                          .ToList()) : null));


        #endregion

        #region DocumentTeacher110Set DTOS
        CreateMap<DocumentTeacher110SetUpdatedDTO, DocumentTeacher110Set>();
        CreateMap<DocumentTeacher110SetConfirmStudyDepDTO, DocumentTeacher110Set>();
        CreateMap<DocumentTeacher110Set, DocumentTeacher110SetReadedDTO>();
        CreateMap<DocumentTeacher110Set, DocumentTeacher110SetAdminReadedDTO>();
        CreateMap<DocumentTeacher110SetCreatedDTO, DocumentTeacher110Set>();
        CreateMap<DocumentTeacher110SetList, DocumentTeacher110SetListReadedDTO<DocumentTeacher110SetReadedDTO>>();
        CreateMap<DocumentTeacher110SetList, DocumentTeacher110SetListReadedDTO<DocumentTeacher110SetAdminReadedDTO>>();
        #endregion

        #region RectorGiven DTOS

        //PersonData
        CreateMap<PersonData, RectorDataGetAllDTO>();
        CreateMap<PersonData, RectorDataGetDTO>();
        CreateMap<RectorDataUpdateDTO, PersonData>();
        CreateMap<PersonDataTranslation, RectorDataTranslationReadedDTO>();
        CreateMap<RectorDataTranslationUpdatedDTO, PersonDataTranslation>();

        #endregion

    }
}



