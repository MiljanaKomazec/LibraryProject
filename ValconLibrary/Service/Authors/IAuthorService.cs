using CSharpFunctionalExtensions;
using ValconLibrary.DTO.Authors;
using ValconLibrary.Entities;

namespace ValconLibrary.Service.Authors
{
    public interface IAuthorService
    {
        List<AuthorDTO> GetAll();
        AuthorDTO GetById(Guid authorId);
        Task<Result<AuthorDTO, IEnumerable<string>>> Create(AuthorCreateDTO authorCreateDTO);
        Task<Result<AuthorDTO, IEnumerable<string>>> Update(AuthorUpdateDTO authorUpdateDto);
        bool Delete(Guid authorId);
    }
}
