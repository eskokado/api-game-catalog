using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class GameEntity : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<StarEntity> Stars { get; set; }

    }
}
