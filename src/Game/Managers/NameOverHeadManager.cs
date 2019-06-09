﻿#region license

//  Copyright (C) 2019 ClassicUO Development Community on Github
//
//	This project is an alternative client for the game Ultima Online.
//	The goal of this is to develop a lightweight client considering 
//	new technologies.  
//      
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassicUO.Game.GameObjects;
using ClassicUO.Game.UI.Gumps;

namespace ClassicUO.Game.Managers
{
    [Flags]
    enum NameOverheadTypeAllowed
    {
        All,
        Mobiles,
        Items,
    }

    static class NameOverHeadManager
    {
        public static NameOverheadTypeAllowed TypeAllowed { get; set; }

        private static NameOverHeadHandlerGump _gump;

        public static bool IsAllowed(Entity serial)
        {
            if (serial == null)
                return false;

            if (TypeAllowed == NameOverheadTypeAllowed.All)
                return true;

            if (serial.Serial.IsItem && TypeAllowed == NameOverheadTypeAllowed.Items)
                return true;

            return serial.Serial.IsMobile && TypeAllowed == NameOverheadTypeAllowed.Mobiles;
        }

        public static void Open()
        {
            if (_gump != null)
                return;

            _gump = new NameOverHeadHandlerGump();
            Engine.UI.Add(_gump);
        }

        public static void Close()
        {
            if (_gump != null)
            {
                _gump.Dispose();
                _gump = null;
            }
        }
    }
}
