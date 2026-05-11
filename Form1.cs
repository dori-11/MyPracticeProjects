using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class label1 : Form
    {
        Bitmap originBmp;
        public label1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()) // 파일 창 생성
            {
                ofd.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp"; // 확장자 필터링 (엉뚱한 파일 못 고르게 막기)

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (Image tempImg = Image.FromFile(ofd.FileName))
                    {
                        picCanvas.Image = new Bitmap(tempImg);
                    }
                    // 사진 불러오기
                    // [중요] 나중에 수정을 하려면 파일에서 직접 불러오는 것보다 
                    // 새로운 Bitmap 객체로 복사해서 메모리에 올리는 게 안전해.
                    Image img = Image.FromFile(ofd.FileName);

                    lblInfo.Text = $"파일명: {ofd.SafeFileName} ({img.Width} x {img.Height})"; // 정보표시

                    img.Dispose(); //사용한 원본 파일 자원은 바로 해제
                }
            }
            originBmp = new Bitmap(picCanvas.Image);
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (picCanvas.Image == null) return;

            Bitmap oldBitmap = new Bitmap(picCanvas.Image);

            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);

            for (int y = 0; y < oldBitmap.Height; y++)
            {
                for (int x = 0; x < oldBitmap.Width; x++)
                {
                    Color c = oldBitmap.GetPixel(x, y);

                    int gray = (int)((c.R + c.G + c.B) / 3);

                    Color grayColor = Color.FromArgb(gray, gray, gray);

                    newBitmap.SetPixel(x, y, grayColor);
                }
            }
            picCanvas.Image = newBitmap;
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (picCanvas.Image == null) return;

            // 1. 원본 이미지를 복사해서 Bitmap 객체 생성
            Bitmap bmp = new Bitmap(picCanvas.Image);
            Bitmap newBmp = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);

                    // 반전 로직 (정확함!)
                    int r = 255 - c.R;
                    int g = 255 - c.G;
                    int b = 255 - c.B;

                    newBmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            // 2. 기존 이미지 메모리 해제 
            if (picCanvas.Image != null) picCanvas.Image.Dispose();

            // 3. 새 이미지 할당 및 갱신
            picCanvas.Image = newBmp;
            picCanvas.Refresh(); 
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (picCanvas.Image == null) return; // 사진이 없으면 계산 시작 하지 마셈.

            Bitmap bmp = (Bitmap)picCanvas.Image; // 현재 화면의 이미지를 비트맵으로 준비

            Bitmap newBmp = new Bitmap(bmp.Width, bmp.Height); // 결과물을 담을 똑같은 빈 비트맵 준비

            for (int y = 0; y < bmp.Height; y++) // 모든 픽셀 하나씩 지나가기
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y); // 한 점의 픽셀에서 색 확인

                    int targetX = (bmp.Width - 1) - x; // 대칭좌표 계산. 공식 (전체 너비 -1) - 현재위치

                    newBmp.SetPixel(targetX, y, c); // 반대편에 찍기.
                }
            }
            picCanvas.Image = newBmp; // 완성된 사진을 불러와.

            // -1을 하는 이유는 컴퓨터는 0부터 세기 때문에 오류 방지.
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picCanvas.Image == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "편집한 이미지 저장하기";
                sfd.FileName = "ResultImage";
                sfd.Filter = "PNG Image|*.png|JPG Image|*.jpg|Bitmap Image|*.bmp";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg")
                        picCanvas.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (ext == ".png")
                        picCanvas.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    else
                        picCanvas.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    MessageBox.Show("성공적으로 저장되었습니다.");
                }
            }
        }

        private void tkBrightness_Scroll(object sender, EventArgs e)
        {
            if (originBmp == null) return; // 원본이 없으면 실행 안 함

            // 항상 원본에서 새로 시작함!
            Bitmap newBmp = new Bitmap(originBmp.Width, originBmp.Height);

            int val = tkBrightness.Value;

            for (int y = 0; y < originBmp.Height; y++)
            {
                for (int x = 0; x < originBmp.Width; x++)
                {
                    Color c = originBmp.GetPixel(x, y); // 원본에서 픽셀 가져오기

                    // ... (밝기 연산 및 클램핑 로직은 그대로) ...
                    int r = Math.Max(0, Math.Min(255, c.R + val));
                    int g = Math.Max(0, Math.Min(255, c.G + val));
                    int b = Math.Max(0, Math.Min(255, c.B + val));

                    newBmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            // 이전 이미지 메모리 해제 후 화면 갱신
            if (picCanvas.Image != null) picCanvas.Image.Dispose();
            picCanvas.Image = newBmp;
        }

        private void tkContrast_Scroll(object sender, EventArgs e)
        {
            if (originBmp == null) return; // 원본 없으면 실행 안함

            Bitmap newBmp = new Bitmap(originBmp.Width, originBmp.Height); // 빈 비트맵 만들기

            double contrast = Math.Pow((100.0 + tkContrast.Value) / 100.0, 2); // 대비 강도 조절 공식

            // 모든 픽셀을 하나씩 방문

            for (int y = 0; y < originBmp.Height; y++)
            {
                for (int x = 0; x < originBmp.Width; x++)
                {
                    Color c = originBmp.GetPixel(x, y); // 픽셀 불러오기

                    // 색 대비 공식

                    double r = ((((c.R / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    double g = ((((c.G / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    double b = ((((c.B / 255.0) - 0.5) * contrast) + 0.5) * 255.0;

                    // 클램핑 적용. 연산 결과가 0보다 작으면 0, 255보다 크면 255로 고정

                    int finalR = Math.Max(0, Math.Min(255, (int)r));
                    int finalG = Math.Max(0, Math.Min(255, (int)g));
                    int finalB = Math.Max(0, Math.Min(255, (int)b));

                    newBmp.SetPixel(x, y, Color.FromArgb(finalR, finalG, finalB));  // 새 비트맵에 계산 결과 적용
                }
            }

            // 기존 메모리 정리 후 새 이미지 출력
            if (picCanvas.Image != null)picCanvas.Image.Dispose(); 
            picCanvas.Image = newBmp;
        }

        private void tkSaturation_Scroll(object sender, EventArgs e)
        {
            if (originBmp == null) return; // 사진이 없으면 계산하지 말기.

            Bitmap newBmp = new Bitmap(originBmp.Width, originBmp.Height); // 새로운 비트맵 만들기

            double saturation = tkSaturation.Value / 100.0; // 채도 계수

            // 픽셀 하나씩 방문하기

            for(int y = 0; y < originBmp.Height; y++)
            {
                for (int x = 0; x < originBmp.Width; x++)
                {
                    Color c = originBmp.GetPixel(x, y); // 픽셀 도착

                    // 평균 밝기(무채색) 계산

                    int gray = (c.R + c.G + c.B) / 3;

                    // 채도 공식 적용

                    double r = gray + (c.R - gray) * saturation;
                    double g = gray + (c.G - gray) * saturation;
                    double b = gray + (c.B - gray) * saturation;

                    // 클램핑 (역시나 0보다 작으면 0, 255보다 크면 255로 고정)

                    int finalR = Math.Max(0, Math.Min(255, (int)r));
                    int finalG = Math.Max(0, Math.Min(255, (int)g));
                    int finalB = Math.Max(0, Math.Min(255, (int)b));

                    // 계산된 결과 비트맵에 찍기

                    newBmp.SetPixel(x, y, Color.FromArgb(finalR, finalG, finalB));
                }
            }

            // 화면 갱신

            if (picCanvas.Image != null) picCanvas.Image.Dispose();
            picCanvas.Image = newBmp;
        }

        private void btnRotateR_Click(object sender, EventArgs e)
        {
            if (picCanvas.Image == null) return;

            Bitmap oldBmp = new Bitmap(picCanvas.Image);
            Bitmap newBmp = new Bitmap(oldBmp.Height, oldBmp.Width);

            for (int y = 0; y < oldBmp.Height; y++)
            {
                for (int x = 0; x < oldBmp.Width; x++)
                {
                    Color c = oldBmp.GetPixel(x, y);

                    int newX = (oldBmp.Height - 1) - y;
                    int newY = x;

                    newBmp.SetPixel(newX, newY, c);
                }
            }
            picCanvas.Image = newBmp;

            if (originBmp != null) originBmp.Dispose();
            originBmp = new Bitmap(newBmp);

            oldBmp.Dispose();
        }

        private void btnRotateL_Click(object sender, EventArgs e)
        {
            if (picCanvas.Image == null) return; // 새 비트맵 준비

            // 비트맵과 같은 크기의 비트맵 준비

            Bitmap oldBmp = new Bitmap(picCanvas.Image);
            Bitmap newBmp = new Bitmap(oldBmp.Height, oldBmp.Width);

            // 픽셀 하나 씩 방문

            for (int y = 0; y < oldBmp.Height; y++)
            {
                for (int x = 0; x < oldBmp.Width; x++)
                {
                    Color c = oldBmp.GetPixel(x, y);

                    int newX = y;
                    int newY = (oldBmp.Width - 1) - x;

                    newBmp.SetPixel(newX, newY, c);
                }
            }
            picCanvas.Image = newBmp;

            if (originBmp != null) originBmp.Dispose();
            originBmp = new Bitmap(newBmp);

            oldBmp.Dispose();
        }

        private void bthFlip_Click(object sender, EventArgs e)
        {
            if (picCanvas == null) return; // 도화지 준비

            // 가로세로 크기가 똑같은 도화지 하나 더

            Bitmap oldBmp = new Bitmap(picCanvas.Image);
            Bitmap newBmp = new Bitmap(oldBmp.Width, oldBmp.Height);

            // 픽셀 하나 씩 방문

            for (int y = 0; y < oldBmp.Height; y++)
            {
                for(int x = 0; x < oldBmp.Width; x++)
                {
                    Color c = oldBmp.GetPixel(x, y); // 픽셀이 도착헀을 때

                    // 좌우 반전 공식

                    int newX = (oldBmp.Width - 1) - x;
                    int newY = y;

                    newBmp.SetPixel(newX, newY, c); // 새 도화지에 픽셀 찍기
                }
            }
            // 초기화

            picCanvas.Image = newBmp;

            if(originBmp != null) originBmp.Dispose();
            originBmp = new Bitmap(newBmp);

            oldBmp.Dispose();
        }
    }
}
