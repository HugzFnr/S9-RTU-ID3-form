using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionTree;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int CurrentQuestionIndex
        {
            get { return currentQuestionIndex; }
            set { if (value<10 && value>=0) currentQuestionIndex = value;
                RefreshQuestion();
            }
        }

        static Random r;

        SetOfQuestions set1;
        List<Answer> answers;
        string[] inputs;
        int currentQuestionIndex;

        DataTable answersTable;
        DataColumn column;
        DataRow row;

        Tree decisionTree;
        DecisionTree.TreeNode currentNode;
        bool id3enabled;

        List<int> usedQuestions;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            set1 = new SetOfQuestions(new string[10] { "How is the weather?", "How was the weather yesterday?",
            "How is the temperature ?","How do you feel today?",
            "Which season is it ?","How is the humidity ?","What’s the plant type?","What’s the lifetime of the plant?",
            "How are the plants looking ? ","Shall I go watering my plants today ?"},
            new string[10] { "Today weather", "Yesterday weather",
            "Temperature","Tiredness",
            "Season","Humidity","Plant type","Lifetime"
             , "Plant looking" , "Ffinal answer"},
            new List<string>[10] { new List<string>{"RAINY", "SUNNY", "CLOUDY"},
            new List<string>{"RAINY2","SUNNY2","CLOUDY2"},  new List<string>{"COLD","WARM","HOT"},
            new List<string>{"EXHAUSTED","TIRED","GOOD","GREAT"},  new List<string>{"SPRING","SUMMER","AUTUMN","WINTER"},
            new List<string>{"LOW","AVERAGE","HIGH"}, new List<string>(), new List<string>{"SHORT","LONG"}, new List<string>(),
            new List<string>{"YES","NO"} });

            InitDataTable();

            r = new Random();

            answers = new List<Answer>();
            currentQuestionIndex = 0;
            inputs = new string[10];
            usedQuestions = new List<int>();

            RefreshQuestion();
        }

        private void RefreshQuestion()
        {
            usedQuestions.Add(CurrentQuestionIndex);

            cbAnswers.Items.Clear();

            lblQuestion.Text = set1.Questions[CurrentQuestionIndex];
            List<string> choices = set1.Possibilities[CurrentQuestionIndex];

            if (choices.Count>0)
            {
                foreach (string s in choices)
                {
                    cbAnswers.Items.Add(s);
                }
                cbAnswers.DropDownStyle= ComboBoxStyle.DropDownList;
            }
            else
            {
                cbAnswers.DropDownStyle = ComboBoxStyle.Simple;
            }
            cbAnswers.Refresh();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            inputs[CurrentQuestionIndex] = cbAnswers.Text;

            if (CurrentQuestionIndex == 9)
            {
                if (id3enabled && cbAnswers.Text != currentNode.Name)
                {
                    AskNextRemainingQuestion();
                    id3enabled = false;
                }//if the final answer is not the one in the tree
                else newAnswer();
            }
            else if (!id3enabled)
            {
                AskNextRemainingQuestion();
            }
            else
            {
                DecisionTree.TreeNode nextNode = NextNodeFromAnswer(inputs[CurrentQuestionIndex], currentNode);
                if (nextNode.IsLeaf && nextNode.Name!="newpath")
                {
                    CurrentQuestionIndex = 9;
                }
                else if (nextNode.Name=="newpath")
                {
                    AskNextRemainingQuestion();
                    id3enabled = false;
                }
                else
                {
                    CurrentQuestionIndex = IndexFromFactor(nextNode.Name);
                }
                currentNode = nextNode;

            }
            stepButton.Enabled = false;
        }
        private void newAnswer()
        {
            usedQuestions.Clear();
            Answer newAnswer = new Answer(set1, inputs);

            bool IsNewAnswer = true;
            foreach (Answer a in answers)
            {
                if (a.IsSameAnswer(newAnswer)) IsNewAnswer = false;
            }

            if (IsNewAnswer)
            {
                answers.Add(newAnswer);
                AddAnswerRow(newAnswer);
                lblNumberCount.Text = answers.Count.ToString();
            }
            //if (answers.Count > 0) lblNumberCount.Text = answers[answers.Count-1].entries[0];

            inputs = new string[10];

            if (answers.Count>=15)
            {
                decisionTree = new Tree();
                decisionTree.Root = Tree.Learn(answersTable, "");
                currentNode = decisionTree.Root;
                id3enabled = true;
            }

            if (!id3enabled)
            {
                CurrentQuestionIndex = 0;
            }
            else
            {
                CurrentQuestionIndex = IndexFromFactor(currentNode.Name);
            }
        }

        private void cbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnswers.Text != null) stepButton.Enabled = true;
        }
        private void cbAnswers_TextChanged(object sender, EventArgs e)
        {
            if (cbAnswers.Text != null) stepButton.Enabled = true;
        }

        private void InitDataTable()
        {
            answersTable = new DataTable("Answers Table");

            foreach (string s in set1.Factors)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = s;
                answersTable.Columns.Add(column);
            }
        }
        private void AddAnswerRow(Answer newAnswer)
        {
            row = answersTable.NewRow();
            for (int i=0; i<set1.Factors.Length;i++)
            {
                row[set1.Factors[i]] = newAnswer.entries[i];
            }
            answersTable.Rows.Add(row);

            dataviewAnswers.DataSource = answersTable;
        }

        private void btnCheat_Click(object sender, EventArgs e)
        {
            //generate 15 random answers
            for (int n=0;n<15;n++)
            {
                string[] simulations = new string[10];
                for (int q=0;q<10;q++)
                {
                    List<string> possibilities = set1.Possibilities[q];
                    int randomIndex = r.Next(possibilities.Count);
                    string generatedAnswer;
                    if (possibilities.Count != 0) generatedAnswer = possibilities[randomIndex];
                    else generatedAnswer = "random free answer";
                    if (q == 0) simulations[q] = "SUNNY";
                    else simulations[q] = generatedAnswer;
                }
                Answer ans = new Answer(set1,simulations);
                answers.Add(ans);
                AddAnswerRow(ans);

                lblNumberCount.Text = answers.Count.ToString();
            }
            lblNumberCount.Text = answers.Count.ToString();
            //if (answers.Count > 0) lblNumberCount.Text = answers[answers.Count-1].entries[0];

            inputs = new string[10];

            if (answers.Count >= 15)
            {
                decisionTree = new Tree();
                decisionTree.Root = Tree.Learn(answersTable, "");
                currentNode = decisionTree.Root;
                id3enabled = true;
            }

            if (!id3enabled)
            {
                CurrentQuestionIndex = 0;
            }
            else
            {
                CurrentQuestionIndex = IndexFromFactor(currentNode.Name);
            }
        }

        private int IndexFromFactor(string factor)
        {
            int index;

            index = Array.FindIndex(set1.Factors, e => e == factor);

            return index;
        }

        private DecisionTree.TreeNode NextNodeFromAnswer(string answer, DecisionTree.TreeNode parentNode)
        {
            foreach (DecisionTree.TreeNode n in parentNode.ChildNodes)
            {
                if (n.Edge == answer) return n;
            }
            return new DecisionTree.TreeNode(true, "newpath", ""); //if this is a new case
        }

        private void AskNextRemainingQuestion()
        {
            int tryIndex = 0;
            while (usedQuestions.Contains(tryIndex))
            {
                tryIndex++;
            }
            CurrentQuestionIndex = tryIndex;
            if (usedQuestions.Count > 10) newAnswer();
        }
    

    }
}
