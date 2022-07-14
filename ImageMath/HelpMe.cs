using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMath
{
    public partial class HelpMe : Form
    {
        public HelpMe()
        {
            InitializeComponent();

            textBox1.Text = @"exp:		Returns E raised to the power specified by a complex number;
log:		Returns the natural logarithm of a complex nuber;
abs:		Returns the magnitude of a complex number;
pi:		Returns pi;
sin:		Returns the sine of a complex number;
cos:		Returns the cos of a complex number;
tan:		Returns the tangent of a complex number;
sqrt:		Returns the square root of a complex number;
pow:		Returns a specified complex number to the power specified by a complex number;
mod:		Returns the remainder of a.Real / b.Real (imaginary part is unaffected);
rotate:		Rotation specified by a real number in radians;
skew:		Skewing the real part;
mirror:		Mirroring;
im:		Returns the input with the real part set to zero;
real:		Returns the input with the imaginary part set to zero;
swap:		Swapping the real and imaginary part;
expmod:		Performs esp and mod operation and uses the ploygonpoints as a limit;";
        }
    }
}
