![enter image description here](https://raw.githubusercontent.com/ouzdev/ReCapProject/master/rent-a-car-project-banner.png)
## Project Tree Structure
```
📦 Recap .Net Core 5.0 Web API Tree View
├─ Business
│  ├─ Abstract
│  │  ├─ IAuthService.cs
│  │  ├─ IBrandService.cs
│  │  ├─ ICarImageService.cs
│  │  ├─ ICarService.cs
│  │  ├─ IColorService.cs
│  │  ├─ ICustomerService.cs
│  │  ├─ IRentalService.cs
│  │  └─ IUserService.cs
│  ├─ Business.csproj
│  ├─ BusinessAspects
│  │  └─ Autofac
│  │     └─ SecuredOperation.cs
│  ├─ Concrete
│  │  ├─ AuthManager.cs
│  │  ├─ BrandManager.cs
│  │  ├─ CarImageManager.cs
│  │  ├─ CarManager.cs
│  │  ├─ ColorManager.cs
│  │  ├─ CustomerManager.cs
│  │  ├─ RentalManager.cs
│  │  └─ UserManager.cs
│  ├─ Constants
│  │  └─ Messages.cs
│  ├─ DependencyResolvers
│  │  └─ Autofac
│  │     └─ AutofacBusinessModule.cs
│  └─ ValidationRules
│     └─ FluentValidation
│        ├─ BrandValidator.cs
│        ├─ CarImageValidator.cs
│        ├─ CarValidator.cs
│        ├─ ColorValidator.cs
│        ├─ CustomerValidator.cs
│        ├─ RentalValidator.cs
│        └─ UserValidator.cs
├─ Core
│  ├─ Aspects
│  │  └─ Autofac
│  │     ├─ Caching
│  │     │  ├─ CacheAspect.cs
│  │     │  └─ CacheRemoveAspect.cs
│  │     ├─ Performance
│  │     │  └─ PerformanceAspect.cs
│  │     └─ Validation
│  │        └─ ValidationAspect.cs
│  ├─ Constants
│  │  └─ Messages.cs
│  ├─ Core.csproj
│  ├─ CrossCuttingConcerns
│  │  ├─ Caching
│  │  │  ├─ ICacheManager.cs
│  │  │  └─ Microsoft
│  │  │     └─ MemoryCacheManager.cs
│  │  └─ Validation
│  │     └─ ValidationTool.cs
│  ├─ DataAccess
│  │  ├─ EntityFramework
│  │  │  └─ EfEntityRepositoryBase.cs
│  │  └─ IEntityRepository.cs
│  ├─ DependencyResolvers
│  │  └─ CoreModule.cs
│  ├─ Entities
│  │  ├─ Concrete
│  │  │  ├─ OperationClaim.cs
│  │  │  ├─ User.cs
│  │  │  └─ UserOperationClaim.cs
│  │  ├─ IDto.cs
│  │  └─ IEntity.cs
│  ├─ Extensions
│  │  ├─ ClaimExtensions.cs
│  │  ├─ ClaimsPrincipalExtensions.cs
│  │  └─ ServiceCollectionExtensions.cs
│  └─ Utilities
│     ├─ Business
│     │  └─ BusinessRules.cs
│     ├─ FileHelper
│     │  ├─ Abstract
│     │  │  └─ IFileHelper.cs
│     │  └─ Concrete
│     │     └─ FileHelper.cs
│     ├─ Interceptors
│     │  ├─ AspectInterceptorSelector.cs
│     │  ├─ MethodInterception.cs
│     │  └─ MethodInterceptionBaseAttribute.cs
│     ├─ IoC
│     │  ├─ ICoreModule.cs
│     │  └─ ServiceTool.cs
│     ├─ Result
│     │  ├─ DataResult.cs
│     │  ├─ ErrorDataResult.cs
│     │  ├─ ErrorResult.cs
│     │  ├─ IDataResult.cs
│     │  ├─ IResult.cs
│     │  ├─ Result.cs
│     │  ├─ SuccessDataResult.cs
│     │  └─ SuccessResult.cs
│     └─ Security
│        ├─ Encryption
│        │  ├─ SecurityKeyHelper.cs
│        │  └─ SigningCredentialsHelper.cs
│        ├─ Hashing
│        │  └─ HashingHelper.cs
│        └─ JWT
│           ├─ Abstract
│           │  └─ ITokenHelper.cs
│           ├─ AccessToken.cs
│           ├─ JwtHelper.cs
│           └─ TokenOptions.cs
├─ DataAccess
│  ├─ Abstract
│  │  ├─ IBrandDal.cs
│  │  ├─ ICarDal.cs
│  │  ├─ ICarImageDal.cs
│  │  ├─ IColorDal.cs
│  │  ├─ ICustomerDal.cs
│  │  ├─ IRentalDal.cs
│  │  └─ IUserDal.cs
│  ├─ Concrete
│  │  ├─ EntityFramework
│  │  │  ├─ EfBrandDal.cs
│  │  │  ├─ EfCarDal.cs
│  │  │  ├─ EfCarImageDal.cs
│  │  │  ├─ EfColorDal.cs
│  │  │  ├─ EfCustomerDal.cs
│  │  │  ├─ EfRentalDal.cs
│  │  │  ├─ EfUserDal.cs
│  │  │  └─ ReCapContext.cs
│  │  └─ InMemory
│  │     └─ InMemoryCarDal.cs
│  ├─ DataAccess.csproj
│  └─ Migrations
│     ├─ 20210214114541_Initialize.Designer.cs
│     ├─ 20210214114541_Initialize.cs
│     ├─ 20210214170404_newTables.Designer.cs
│     ├─ 20210214170404_newTables.cs
│     └─ ReCapContextModelSnapshot.cs
├─ Entities
│  ├─ Concrete
│  │  ├─ Brand.cs
│  │  ├─ Car.cs
│  │  ├─ CarImage.cs
│  │  ├─ Color.cs
│  │  ├─ Customer.cs
│  │  └─ Rental.cs
│  ├─ DTOs
│  │  ├─ BrandDTOs
│  │  │  └─ AddBrandDto.cs
│  │  ├─ CarDetailsDTO.cs
│  │  ├─ CarImageDTOs
│  │  │  ├─ AddCarImageDto.cs
│  │  │  └─ UpdateCarImageDto.cs
│  │  ├─ RentalDTOs
│  │  │  └─ GetRentalDetailDTO.cs
│  │  └─ UserDTOs
│  │     ├─ UserForLoginDto.cs
│  │     └─ UserForRegisterDto.cs
│  └─ Entities.csproj
├─ README.md
├─ ReCapProject.sln
├─ WebAPI
│  ├─ Controllers
│  │  ├─ AuthController.cs
│  │  ├─ BrandsController.cs
│  │  ├─ CarImagesController.cs
│  │  ├─ CarsController.cs
│  │  ├─ ColorsController.cs
│  │  ├─ CustomersController.cs
│  │  ├─ RentalsController.cs
│  │  └─ UsersController.cs
│  ├─ Program.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ Startup.cs
│  ├─ ViewModels
│  │  └─ MapperProfile.cs
│  ├─ WebAPI.csproj
│  ├─ appsettings.Development.json
│  ├─ appsettings.json
│  └─ wwwroot
│     └─ images
│        ├─ 00dfccbf-5f64-4bfd-bafe-971304a2eacc.jpg
│        ├─ 0ec4b368-da70-448e-933d-9247febe38fc.jpg
│        ├─ 0ffe7fa2-2e02-4a51-a912-f0ebc558ced1.jpg
│        ├─ 148d1417-ae11-42e9-990e-6a324618dd70.jpg
│        ├─ 1fd8a04f-e995-42aa-bb10-b39b27ef825f.jpg
│        ├─ 2efb130b-7f2d-4d6c-bb00-5c6bdcaee140.jpg
│        ├─ 3dd89eac-5b38-4bfb-897e-a877bf6dcb7d.jpg
│        ├─ 5c1a5feb-1320-49cc-8f4e-c36e0d47d5dd.jpg
│        ├─ 615b1d4d-d27c-4bc2-b637-ae9ed6f435c4.jpg
│        ├─ 6abba55c-d734-4910-9277-d2de8cde2026.jpg
│        ├─ 841bc992-220b-418d-80ab-f96a54cac31a.jpg
│        ├─ 91b4f84d-5e61-4355-9387-140037be67bc.jpg
│        ├─ a065c281-7f7b-46f5-911b-bd93d855136d.jpg
│        ├─ bd9896c5-ac1d-484d-96a8-b959e990b9cb.jpg
│        ├─ e05a9019-4605-4b34-bfe7-808b00a0b230.jpg
│        ├─ e0c486d5-7634-427c-8ff2-65564e65f8af.jpg
│        ├─ e594452f-e7b2-483e-903e-8048405f6f67.jpg
│        ├─ f15da437-f414-49a4-94bd-422a0503a80f.jpg
│        ├─ f6cc48be-9369-4234-86c7-1b8d34e7a7d7.jpg
│        └─ placeholder.png
└─ rent-a-car-project-banner.png
```
