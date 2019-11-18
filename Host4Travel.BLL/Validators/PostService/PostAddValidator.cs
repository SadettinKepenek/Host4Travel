using System;
using FluentValidation;
using Host4Travel.BLL.Validators.PostCategoryRewardService;
using Host4Travel.BLL.Validators.PostImageService;
using Host4Travel.Core.DTO.PostService;

namespace Host4Travel.BLL.Validators.PostService
{
    public class PostAddValidator : AbstractValidator<PostAddDto>
    {
        public PostAddValidator()
        {
            RuleFor(x => x.Latitude).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty()
                .WithMessage("Latitude alanı boş geçilemez.");
            RuleFor(x => x.Longitude).NotNull().NotEmpty().WithMessage("Longitude alanı boş geçilemez");
            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Başlama tarihi boş geçilemez");
            RuleFor(x => x.StartDate).LessThanOrEqualTo(y => y.EndDate)
                .WithMessage("Başlama tarihi bitiş tarihinden küçük yada eşit olmalıdır.");
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("İlan başlangıç tarihi, bugün veya daha ilerisi için olabilir.");
            RuleFor(x => x.EndDate).NotNull().NotEmpty().WithMessage("Bitiş tarihi boş geçilemez.");
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(y => y.StartDate)
                .WithMessage("Bitiş tarihi,başlama tarihinden büyük yada eşit olmaldıır.");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Post Aktif durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Post Sahibi alanı belirtilmelidir.");
            RuleFor(x => x.PostDescription).NotNull().NotEmpty().WithMessage("Post Açıklaması belirtilmelidir.");
            RuleFor(x => x.PostDescription).MinimumLength(50)
                .WithMessage("Post Açıklaması Minimum 50 karakterden oluşmalıdır.");
            RuleFor(x => x.PostDescription).MaximumLength(1000)
                .WithMessage("Post Açıklaması Maximum 1000 karakterden oluşmalıdır.");
            RuleFor(x => x.PostTitle).NotNull().NotEmpty().WithMessage("Post Başlığı belirtilmelidir.");
            RuleFor(x => x.PostTitle).MinimumLength(10).WithMessage("Post Başlığı Minumum 10 karakterden oluşmalıdır.");
            RuleFor(x => x.PostTitle).MaximumLength(150)
                .WithMessage("Post Başlığı Maximum 150 karakterden oluşmalıdır.");
            RuleFor(x => x.PostType).NotNull().NotEmpty().WithMessage("Post Türü Seçilmelidir");

            RuleFor(x => x.PostImage).NotNull().NotEmpty().WithMessage("Post Resimleri Boş Olamaz");
            RuleForEach(x => x.PostImage).NotNull().NotEmpty().SetValidator(new AddPostImageValidator()).WithMessage("Post Resimleri Doğru Değil");
            RuleFor(x => x.PostCategoryReward).NotNull().NotEmpty()
                .WithMessage("Post Category & Rewardleri Boş olamaz");
            RuleForEach(x => x.PostCategoryReward).SetValidator(new AddPostCategoryRewardValidator())
                .WithMessage("Post Category Rewardleri doğru değil");

        }
    }
}