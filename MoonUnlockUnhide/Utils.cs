using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	internal class Utils
	{
		internal static FieldInfo getInternalStaticField(string typeName, string fieldName)
		{
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				FieldInfo field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
				if (field != null)
				{
					return field;
				}
			}
			return null;
		}
	}
}
