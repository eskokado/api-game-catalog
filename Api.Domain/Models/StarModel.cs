using System;

namespace Api.Domain.Models
{
    public class StarModel : BaseModel
    {
        private Guid _playerId;
        public Guid PlayerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        
        private Guid _gameId;
        public Guid GameId
        {
            get { return _gameId; }
            set { _gameId = value; }
        }       

        private int _star;
        public int Star
        {
            get { return _star; }
            set { _star = value; }
        }
        
    }
}