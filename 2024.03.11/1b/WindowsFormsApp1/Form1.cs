﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1
            List<Books> books = new List<Books>();
            string[] sorok = File.ReadAllLines("books.txt");
            foreach (var s in sorok)
            {
                string[] values = s.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books.Add(books_object);
            }
            //2
            int bookdb = 0;
            foreach (var book in books)
            {
                bookdb += book.mennyiseg;
            }

            label1.Text = String.Format("Az össz darabszám {0}", bookdb);

            //4
            List<Books> legdragabbak = new List<Books>();
            Books legdragabb = books[0];
            legdragabbak.Add(legdragabb);

            foreach (var book in books)
            {
                if (book.ar > legdragabb.ar)
                {
                    legdragabb = book;
                    legdragabbak.Clear();
                    legdragabbak.Add(legdragabb);
                }
                else if (book.ar == legdragabb.ar)
                {
                    legdragabbak.Add(legdragabb);
                }
            }

            foreach (var legdragabbTermek in legdragabbak)
            {
                dataGridView1.Rows.Add(legdragabbTermek.mufaj, legdragabbTermek.cim, legdragabbTermek.ar);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valasztott = (string)comboBox1.SelectedItem;
            List<Books> books = new List<Books>();
            string[] sorok = File.ReadAllLines("books.txt");
            foreach (var s in sorok)
            {
                string[] values = s.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books.Add(books_object);
            }

            listBox1.Items.Clear();

            foreach (var book in books)
            {
                if (book.mufaj == valasztott)
                {
                    string text = "Cím: " + book.cim + ", Ár: " + book.ar + ", Darab: " + book.mennyiseg;
                    listBox1.Items.Add(text);
                }
            }
        }
    }
}
