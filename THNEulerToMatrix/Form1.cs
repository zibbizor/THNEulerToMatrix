using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX;
using System.Globalization;

namespace THNEulerToMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public float DegreeToRadian(float angle)
        {
            double r = Math.PI * angle / 180.0;
            return (float)r;
        }

        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            float num = roll * 0.5f;
            float num2 = (float)Math.Sin((double)num);
            float num3 = (float)Math.Cos((double)num);
            float num4 = pitch * 0.5f;
            float num5 = (float)Math.Sin((double)num4);
            float num6 = (float)Math.Cos((double)num4);
            float num7 = yaw * 0.5f;
            float num8 = (float)Math.Sin((double)num7);
            float num9 = (float)Math.Cos((double)num7);
            Quaternion result;
            result.X = num9 * num5 * num3 + num8 * num6 * num2;
            result.Y = num8 * num6 * num3 - num9 * num5 * num2;
            result.Z = num9 * num6 * num2 - num8 * num5 * num3;
            result.W = num9 * num6 * num3 + num8 * num5 * num2;
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            float EulerX = float.Parse(TextBoxX.Text);
            float EulerY = float.Parse(TextBoxY.Text);
            float EulerZ = float.Parse(TextBoxZ.Text);

            // X = pitch, Y = yaw, Z = roll,  
            Quaternion q = CreateFromYawPitchRoll(DegreeToRadian(EulerY), DegreeToRadian(EulerX), DegreeToRadian(EulerZ));           
            Matrix matrix = Matrix.RotationQuaternion(q);
            
            string THNOrientationX = "{ " + Math.Round(matrix.M11, 6).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(matrix.M12, 6).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(matrix.M13, 6).ToString(CultureInfo.InvariantCulture) + " }";
            string THNOrientationY = "{ " + Math.Round(matrix.M21, 6).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(matrix.M22, 6).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(matrix.M23, 6).ToString(CultureInfo.InvariantCulture) + " }";
            string THNOrientationZ = "{ " + Math.Round(matrix.M31, 6).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(matrix.M32, 6).ToString(CultureInfo.InvariantCulture) + ", " + Math.Round(matrix.M33, 6).ToString(CultureInfo.InvariantCulture) + " }";
            string THNOrientation = "{" + THNOrientationX + " , " + THNOrientationY + " , " + THNOrientationZ + "}";

            TextBoxResult.Text = THNOrientation;
            //TextBoxResult.Text = EulerX.ToString() + EulerY.ToString() + EulerZ.ToString();

        }
    }
}
