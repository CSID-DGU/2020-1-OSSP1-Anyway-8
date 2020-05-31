﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace TeamPJ_1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            //폴더생성
            if (Directory.Exists(@".\video") == false)
            {
                Directory.CreateDirectory(@".\video");
            }
            string url = metroTextBox1.Text;
            Process p = new Process();
            p.StartInfo.FileName = "__main__.exe";
            p.StartInfo.Arguments = "-f \"bestvideo[height<=1080]\" " + url;
            p.Start();
            p.WaitForExit();
            //파일입출력
            string fileName = getFileName();
            string filePath = ".\\" + fileName;
            string movePath = ".\\video\\" + fileName;
            if (File.Exists(movePath) == false && File.Exists(filePath) == true)
            {
                File.Move(filePath, movePath);
            }
            //파일 이동완료
            if (File.Exists(movePath) == true)
            {
                Form3 mainForm = new Form3();
                mainForm.Passvalue = fileName;
                mainForm.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("동영상 파일을 찾지 못했습니다.");
            }
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            string fileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "파일 찾기";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "mp4 File(*.mp4)|*.mp4 |webm File(*.webm)|*.webm";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                // gif.Image.Save(fileName);
            }
        }

        private void MetroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private string getFileName()
        {
            string path = @".\info.txt";
            string[] textValue = System.IO.File.ReadAllLines(path);
            return textValue[0];
        }
    }

       

}
