using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomType.MVVM.Models
{
    public class CustomTheme : ObservableObject
    {
        public string ThemeName { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string LightColor { get; set; } = null!;

        public override string ToString()
        {
            return ThemeName;
        }
    }
}
