using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class FoodCreator
	{
		int mapWidht;
		int mapHeight;
		char sym;

		Random random = new Random( );

		public FoodCreator(int mapWidth, int mapHeight, char sym)
		{
			this.mapWidht = mapWidth;
			this.mapHeight = mapHeight;
			this.sym = sym;
        }

		public Point CreateFood(Snake snake)
		{
			Point food;
			while (true)
            {
				int x = random.Next(2, mapWidht - 1);
				int y = random.Next(1, mapHeight - 1);
				food = new Point(x, y, sym);
				if (snake.IsHitPoints(food))
                {
					continue;
                }
                else
                {
					return food;
                }
			}

		}
	}
}
