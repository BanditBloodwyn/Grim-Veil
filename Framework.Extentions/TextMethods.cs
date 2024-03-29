﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace Framework.Extentions;
public static class TextMethods
{
    public static int WriteDefaultString(this SpriteBatch spriteBatch, string text, int posX, int posY)
    {
        spriteBatch.DrawString(ResourcePool.Fonts["Default"], text, new Vector2(posX, posY), Color.White);
        
        return (int) ResourcePool.Fonts["Default"].MeasureString(text).Y;
    }
}
