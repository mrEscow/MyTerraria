using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTerraria.NPC
{
    class NpcFastSlime : NpcSlime
    {
        public NpcFastSlime(World world) : base(world)
        {
            rect.FillColor = new Color(255, 0, 0, 200);
        }

        public override Vector2f GetJumpVecocity()
        {
            return new Vector2f(Direction * Program.Rand.Next(15, 100), -Program.Rand.Next(8, 15));
        }
    }
}
