using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerIO.GameLibrary;

namespace ServerDeberc
{
    public class Player:BasePlayer
    {
    }

    [RoomType("DebercRoom")]
    public class GameRoom : Game<Player>
    {
        public override void GameStarted()
        {
        }

        public override void GameClosed()
        {
        }

        public override void UserJoined(Player player)
        {
            foreach (Player _player in Players)
            {
                if (_player.ConnectUserId != player.ConnectUserId)
                {
                    _player.Send("Connect", "Connecting:" + player.ConnectUserId.ToString());
                }
            }
        }

        public override void UserLeft(Player player)
        {
            foreach (Player _player in Players)
            {
                if (_player.ConnectUserId != player.ConnectUserId)
                {
                    _player.Send("Left", "Connecting:" + player.ConnectUserId.ToString());
                }
            }
        }

        public override void GotMessage(Player player, Message message)
        {
        }
    }
}
