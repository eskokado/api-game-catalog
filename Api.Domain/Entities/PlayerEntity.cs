using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public IEnumerable<StarEntity> Stars { get; set; }

    }
}
