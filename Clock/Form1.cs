using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        bool eyesOpen = true;
        Timer blinkTimer;
        Timer clockTimer;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.SkyBlue;
            this.ClientSize = new Size(400, 500);
            this.Text = "Нюша с часами";

            this.Paint += Form1_Paint;

            blinkTimer = new Timer();
            blinkTimer.Interval = 500;
            blinkTimer.Tick += (s, e) =>
            {
                eyesOpen = !eyesOpen;
                this.Invalidate();
            };
            blinkTimer.Start();

            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, e) => this.Invalidate();
            clockTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawNyushaWithPoster(e.Graphics);
        }

        private void DrawNyushaWithPoster(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2 + 40;

            int bodyRadius = 80;
            Rectangle bodyRect = new Rectangle(centerX - bodyRadius, centerY - bodyRadius, bodyRadius * 2, bodyRadius * 2);
            Color bodyColor = Color.FromArgb(255, 170, 200);
            Color outlineColor = Color.FromArgb(220, 60, 100);

            using (SolidBrush bodyBrush = new SolidBrush(bodyColor))
            using (Pen outlinePen = new Pen(outlineColor, 4))
            {
                g.FillEllipse(bodyBrush, bodyRect);
                g.DrawEllipse(outlinePen, bodyRect);
            }

            using (SolidBrush legBrush = new SolidBrush(outlineColor))
            {
                int legWidth = 22, legHeight = 40, legOffsetX = 30;
                g.FillRectangle(legBrush, centerX - legOffsetX - legWidth / 2, centerY + bodyRadius - 10, legWidth, legHeight);
                g.FillRectangle(legBrush, centerX + legOffsetX - legWidth / 2, centerY + bodyRadius - 10, legWidth, legHeight);
            }

            int posterWidth = 220, posterHeight = 80, posterY = centerY - bodyRadius - 120;
            Rectangle posterRect = new Rectangle(centerX - posterWidth / 2, posterY, posterWidth, posterHeight);

            using (SolidBrush posterBrush = new SolidBrush(Color.White))
            using (Pen posterPen = new Pen(Color.Black, 3))
            {
                g.FillRectangle(posterBrush, posterRect);
                g.DrawRectangle(posterPen, posterRect);
            }

            using (Pen armPen = new Pen(bodyColor, 16) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.DrawLine(armPen, centerX - bodyRadius + 10, centerY - 30, posterRect.Left + 30, posterRect.Bottom);
                g.DrawLine(armPen, centerX + bodyRadius - 10, centerY - 30, posterRect.Right - 30, posterRect.Bottom);
            }

            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (Font clockFont = new Font("Arial", 18, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                string timeText = DateTime.Now.ToString("HH:mm:ss");
                g.DrawString(timeText, clockFont, textBrush, posterRect, sf);
            }

            int snoutWidth = 60, snoutHeight = 40;
            Rectangle snoutRect = new Rectangle(centerX - snoutWidth / 2, centerY - 10, snoutWidth, snoutHeight);

            using (SolidBrush snoutBrush = new SolidBrush(outlineColor))
            using (Pen snoutPen = new Pen(Color.DarkRed, 2))
            {
                g.FillEllipse(snoutBrush, snoutRect);
                g.DrawEllipse(snoutPen, snoutRect);
                using (SolidBrush nostrilBrush = new SolidBrush(Color.FromArgb(180, 40, 70)))
                {
                    g.FillEllipse(nostrilBrush, centerX - 15, centerY, 10, 18);
                    g.FillEllipse(nostrilBrush, centerX + 5, centerY, 10, 18);
                }
            }

            int eyeWidth = 26, eyeHeight = 20, eyeOffsetX = 22, eyeY = centerY - 40;
            Rectangle leftEye = new Rectangle(centerX - eyeOffsetX - eyeWidth / 2, eyeY, eyeWidth, eyeHeight);
            Rectangle rightEye = new Rectangle(centerX + eyeOffsetX - eyeWidth / 2, eyeY, eyeWidth, eyeHeight);

            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush pupilBrush = new SolidBrush(Color.Black))
            using (Pen eyePen = new Pen(Color.Black, 2))
            {
                if (eyesOpen)
                {
                    g.FillEllipse(whiteBrush, leftEye);
                    g.FillEllipse(whiteBrush, rightEye);
                    g.DrawEllipse(eyePen, leftEye);
                    g.DrawEllipse(eyePen, rightEye);
                    g.FillEllipse(pupilBrush, centerX - eyeOffsetX - 5, eyeY + 6, 10, 10);
                    g.FillEllipse(pupilBrush, centerX + eyeOffsetX - 5, eyeY + 6, 10, 10);
                }
                else
                {
                    using (Pen lidPen = new Pen(Color.Black, 3))
                    {
                        g.DrawLine(lidPen, leftEye.Left, leftEye.Top + eyeHeight / 2, leftEye.Right, leftEye.Top + eyeHeight / 2);
                        g.DrawLine(lidPen, rightEye.Left, rightEye.Top + eyeHeight / 2, rightEye.Right, rightEye.Top + eyeHeight / 2);
                    }
                }
            }

            using (Pen mouthPen = new Pen(Color.DarkRed, 3) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                Rectangle mouthRect = new Rectangle(centerX - 30, centerY + 20, 60, 30);
                g.DrawArc(mouthPen, mouthRect, 10, 160);
            }

            using (SolidBrush hatBrush = new SolidBrush(outlineColor))
            using (Pen hatPen = new Pen(outlineColor, 3))
            {
                Rectangle hatRect = new Rectangle(centerX - 35, centerY - bodyRadius - 10, 70, 30);
                g.FillEllipse(hatBrush, hatRect);
                g.DrawBezier(hatPen, centerX, hatRect.Top, centerX + 10, hatRect.Top - 20, centerX - 10, hatRect.Top - 30, centerX + 5, hatRect.Top - 40);
            }

            using (SolidBrush flowerBrush = new SolidBrush(Color.FromArgb(255, 80, 120)))
            using (SolidBrush flowerCenterBrush = new SolidBrush(Color.OrangeRed))
            {
                int flowerCenterX = centerX + bodyRadius - 30;
                int flowerCenterY = centerY - bodyRadius + 20;
                int petalRadius = 10;

                for (int i = 0; i < 5; i++)
                {
                    double angle = i * 2 * Math.PI / 5;
                    int px = flowerCenterX + (int)(Math.Cos(angle) * petalRadius * 1.6);
                    int py = flowerCenterY + (int)(Math.Sin(angle) * petalRadius * 1.6);
                    g.FillEllipse(flowerBrush, px - petalRadius, py - petalRadius, petalRadius * 2, petalRadius * 2);
                }

                g.FillEllipse(flowerCenterBrush, flowerCenterX - petalRadius, flowerCenterY - petalRadius, petalRadius * 2, petalRadius * 2);
            }
        }
    }
}

