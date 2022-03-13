using Microsoft.AspNetCore.Mvc;

namespace Infra.Http
{
    public interface IController<T>
    {
        [HttpGet]
        public Task<ICollection<T>> GetAsync();

        [HttpGet("{id:guid}")]
        public Task<T> GetAsync(Guid id);

        [HttpPost]
        public Task<T> PostAsync([FromBody] T user);

        [HttpPatch("{id:guid}")]
        public Task<T> PutAsync(Guid id, [FromBody] T user);

        [HttpDelete("{id:guid}")]
        public Task DeleteAsync(Guid id);
       
    }
}