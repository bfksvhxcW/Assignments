using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2 {
    public partial class FrmCalc : Form {
        private double num1 = 0;
        private double num2 = 0;
        private double ans = 0;
        private string op = "";
        int flag = 0;

        public FrmCalc() {
            InitializeComponent();
        } // 原本的textBox1.Text的值为null，但到了这里已经变为了""

        //flag值为0（或1）时输入第1个操作数，值为1时选择运算符，值为2（或3）时输入第2个操作数，值为3时点击Calculate进行计算
        
        /// <summary>
        /// 输入第1个操作数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                return;
            }
            switch (flag) {
                case 0: // 准备输入第1个操作数
                    try {
                        num1 = double.Parse(textBox1.Text);
                        flag++;
                        break;
                    } catch {
                        MessageBox.Show("请输入数字！", "温馨提示");
                        textBox1.Clear();
                        return;
                    }
                case 1: // 第1个操作数已经开始输入，但还没输入完的时候，比如324才刚输入了第一个数字3
                    try {
                        num1 = double.Parse(textBox1.Text);
                        break;
                    } catch {
                        MessageBox.Show("请输入数字！", "温馨提示");
                        textBox1.Clear();
                        return;
                    }
                case 2: // 已经选择过操作符
                    MessageBox.Show("请输入第2个操作数！", "温馨提示");
                    break;
                case 3: // 已经输入第2个操作数
                    MessageBox.Show("请点击“Calculate”！", "温馨提示");
                    break;
            }
        }

        /// <summary>
        /// 选择了加法运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e) {
            switch (flag) {
                case 0:
                    MessageBox.Show("请先输入第1个操作数！", "温馨提示");
                    break;
                case 1: // 已经输入第1个操作数
                    op = "+";
                    flag++;
                    break;
                case 2: // 已经选择过一个操作数，本计算器的设定为已经选择的操作符不可以被覆盖
                    MessageBox.Show("操作符已无法更改！\n请输入第2个操作数！", "温馨提示！");
                    break;
                case 3:
                    MessageBox.Show("本计算器仅支持双目运算！\n请点击“Calculate”！", "温馨提示");
                    break;
            }
        }

        /// <summary>
        /// 选择了减法运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSub_Click(object sender, EventArgs e) {
            switch (flag) {
                case 0:
                    MessageBox.Show("请先输入第1个操作数！", "温馨提示");
                    break;
                case 1: // 已经输入第1个操作数
                    op = "-";
                    flag++;
                    break;
                case 2: // 已经选择过一个操作数，本计算器的设定为已经选择的操作符不可以被覆盖
                    MessageBox.Show("操作符已无法更改！\n请输入第2个操作数！", "温馨提示！");
                    break;
                case 3:
                    MessageBox.Show("本计算器仅支持双目运算！\n请点击“Calculate”！", "温馨提示");
                    break;
            }
        }

        /// <summary>
        /// 选择了乘法运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulti_Click(object sender, EventArgs e) {
            switch (flag) {
                case 0:
                    MessageBox.Show("请先输入第1个操作数！", "温馨提示");
                    break;
                case 1: // 已经输入第1个操作数
                    op = "*";
                    flag++;
                    break;
                case 2: // 已经选择过一个操作数，本计算器的设定为已经选择的操作符不可以被覆盖
                    MessageBox.Show("操作符已无法更改！\n请输入第2个操作数！", "温馨提示！");
                    break;
                case 3:
                    MessageBox.Show("本计算器仅支持双目运算！\n请点击“Calculate”！", "温馨提示");
                    break;
            }
        }

        /// <summary>
        /// 选择了除法运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, EventArgs e) {
            switch (flag) {
                case 0:
                    MessageBox.Show("请先输入第1个操作数！", "温馨提示");
                    break;
                case 1: // 已经输入第1个操作数
                    op = "/";
                    flag++;
                    break;
                case 2: // 已经选择过一个操作数，本计算器的设定为已经选择的操作符不可以被覆盖
                    MessageBox.Show("操作符已无法更改！\n请输入第2个操作数！", "温馨提示！");
                    break;
                case 3:
                    MessageBox.Show("本计算器仅支持双目运算！\n请点击“Calculate”！", "温馨提示");
                    break;
            }
        }

        /// <summary>
        /// 输入第2个操作数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e) {
            if (textBox2.Text == "") {
                return;
            }
            switch (flag) {
                case 0: // 点击“Calculate”时还没输入第一个操作数
                    MessageBox.Show("请先输入第1个操作数！", "温馨提示");
                    break;
                case 1: // 点击“Calculate”时还没选择操作符
                    MessageBox.Show("请先选择一种操作符！", "温馨提示");
                    break;
                case 2: // 已经选择了操作符，准备输入第2个操作数
                    try {
                        num2 = double.Parse(textBox2.Text);
                        if (op == "/" && num2 == 0) {
                            MessageBox.Show("除数不能为0！\n请重新输入！", "温馨提示");
                            textBox2.Clear();
                            return;
                        }
                        flag++;
                        break;
                    } catch {
                        MessageBox.Show("请输入数字！", "温馨提示");
                        textBox2.Clear();
                        return;
                    }
                case 3: // 第2个操作数还没结束输入时
                    try {
                        num2 = double.Parse(textBox2.Text);
                        break;
                    } catch {
                        MessageBox.Show("请输入数字！", "温馨提示");
                        textBox2.Clear();
                        return;
                    }
            }
        }

        /// <summary>
        /// 点击“Calculate”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e) {
            switch (flag) {
                case 0:
                    MessageBox.Show("请先输入第1个操作数！", "温馨提示");
                    break;
                case 1:
                    MessageBox.Show("请先选择一种操作符！", "温馨提示");
                    break;
                case 2:
                    MessageBox.Show("请先输入第2个操作数！", "温馨提示");
                    break;
                case 3:
                    switch (op) {
                        case "+":
                            ans = num1 + num2;
                            break;
                        case "-":
                            ans = num1 - num2;
                            break;
                        case "*":
                            ans = num1 * num2;
                            break;
                        case "/":
                            ans = num1 / num2;
                            break;
                    }
                    textBox3.Text = Convert.ToString(ans);
                    MessageBox.Show("运算完成！\n"+Convert.ToString(num1)+" "+op+" "+Convert.ToString(num2)+" 的运算结果是 "+Convert.ToString(ans));
                    flag = 0;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    break;
            }
        }
    }
}
