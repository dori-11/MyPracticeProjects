using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Calculator
{
    public partial class Calculator : Form
    {
        decimal firstValue = 0;  // 첫 번째 입력받은 숫자를 저장하는 변수 (10진수 방식 그대로 저장하기 때문에 정확도 높음)
        string currentOp = ""; // 누른 연산자를 기억하는 변수 (글자를 저장하는 string)
        bool isNewInput = true; // 지금 치는 숫자가 새로운 시작인지 판단하는 스위치 (true or false)
        string tempInput = ""; // 화면엔 보이지 않는 숫자를 담아두는 포켓. 텍스트박스 양쪽에 입력값이 나오는걸 방지하기 위해서 사용 (글자를 저장하는 string)
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;  // 0부터 9까지 모든 숫자 버튼이 공유해서 사용 중 (버튼으로 형변환을 해줘야 그 버튼의 텍스트를 가져오는 것.)
            tempInput += btn.Text; // 숫자를 스트링 파입의 주머니에 쌓는것. 문자로 붙여야 n자리 숫자가 됨.

            // 2. 왼쪽 과정창에 출력
            if (txtProcess.Text == "0" || isNewInput) 
            {
                txtProcess.Text = btn.Text;  // 처음 켰을 때, 또는 연산자를 누른 직후 기존 글자를 지우고 방금 누른 숫자로 교체
                isNewInput = false; 
            }
            else
            {
                txtProcess.Text += btn.Text; // 이미 숫자를 치는 중이라면, 기존 숫자 뒤에 새 숫자를 추가.
            }
        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tempInput, out firstValue)) // tempInput안의 글자를 숫자로 변환
            {
                Button btn = (Button)sender;
                currentOp = btn.Text; // 연산자 기호 저장

                if (txtProcess.Text.Contains(" = "))  // 만약에 이미 계산 결과가 '='가 있다면?
                {
                    int index = txtProcess.Text.IndexOf(" = "); // 그 위치를 찾아 앞만 남기고 자르기
                    txtProcess.Text = txtProcess.Text.Substring(0, index);
                }

                txtProcess.Text += " " + currentOp + " "; // 과정창에 연산기호 추가

                tempInput = ""; // 당므 숫자를 새로 받아야 하므로 초기화.
                isNewInput = false; // 새로운 숫자를 치기 위해 false
            }
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tempInput, out decimal secondValue)) // tempInput안에 두 번째 글자를 숫자로 변환.
            {
                decimal result = Calculate(firstValue, secondValue, currentOp); // 별도로 만든 계산 함수 접근

                txtDisplay.Text = result.ToString("#, ##0.################"); // 3자리 콤마 표시
                txtProcess.Text += " = ";

                tempInput = result.ToString(); // 결과값을 저장해 다음 연산의 시작점 만들기.
                isNewInput = true;

                listBox1.Items.Add(txtProcess.Text + result.ToString());
            }
        }
        private decimal Calculate(decimal v1, decimal v2, string op)
        {
            switch (op)  // 저장해둔 연산자에 따라 계산 시수행
            {
                case "+": return v1 + v2;
                case "-": return v1 - v2;
                case "*": return v1 * v2;
                case "/": return v2 != 0 ? v1 / v2 : 0; // 0 나누기 방어
                default: return v2;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProcess.Text = "0";  
            txtDisplay.Text = "";   

            firstValue = 0;
            currentOp = "";
            tempInput = "";
            isNewInput = true;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {

            if (tempInput.Length > 0)
            {
                tempInput = tempInput.Substring(0, tempInput.Length - 1);
                txtProcess.Text = txtProcess.Text.Substring(0, txtProcess.Text.Length - 1);

                if (txtProcess.Text == "" || txtProcess.Text.EndsWith(" "))
                    txtProcess.Text = "0";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!tempInput.Contains("."))
            {
                if (tempInput == "")
                {
                    tempInput = "0.";
                    txtProcess.Text += "0.";
                }
                else
                {
                    tempInput += ".";
                    txtProcess.Text += ".";
                }
                isNewInput = false;
            }
        }

    }
}
