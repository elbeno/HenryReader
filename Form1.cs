using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Specialized;

namespace HenryReader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private int numWords; 
		private int wordIndex; 
		private StringCollection wordList;
		private Random randGen;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			wordList = new StringCollection();
			randGen = new Random();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(600, 398);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button1.Location = new System.Drawing.Point(0, 375);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(600, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Next";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 398);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Henry Reader";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Form1 f = new Form1();
			f.ReadFromFile("words.txt");
			Application.Run(f);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			NextString();
		}

		private void ReInitWordList()
		{
			wordIndex = 0;

			for (int i = 0; i < numWords; ++i)
			{
				int r = randGen.Next(numWords-1);
				if (r != i)
				{
					String s = wordList[i];
					wordList[i] = wordList[r];
					wordList[r] = s;
				}
			}
		}

		private void NextString()
		{
			label1.Text = wordList[wordIndex];
			++wordIndex;
			if (wordIndex >= numWords) ReInitWordList();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			NextString();
		}

		private void ReadFromFile(string filename)
		{
			numWords = 0;
			StreamReader SR;
			string S;
			SR=File.OpenText(filename);
			S=SR.ReadLine();
			while(S!=null)
			{
				if (S.Length > 0)
				{
					++numWords;
					wordList.Add(S);
				}
				S=SR.ReadLine();
			}
			SR.Close();

			ReInitWordList();
		}
	}
}
