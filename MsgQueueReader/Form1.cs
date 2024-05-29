//File:         Form1.cs
//Project:      BI-A02
//Programmer:   Addison Phillips
//Initial Date: January 25, 2024
//Description:  Taken from Norbert's message queue reader example, this keeps similar controls in place but focuses on starting and stopping the reading 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;

namespace MsgQueueReader
{
    public partial class QueueReaderForm : Form
    {
        DatabaseWriter dbw = new DatabaseWriter();
        MessageQueue msmq = new MessageQueue();
        Boolean bRead = false;
        String queueName = "\\private$\\yoyo";

        //Function:     QueueReaderForm
        //Description:  Form constructor.
        public QueueReaderForm()
        {
            InitializeComponent();
            msmq.Formatter = new ActiveXMessageFormatter();
            msmq.MessageReadPropertyFilter.LookupId = true;
            msmq.SynchronizingObject = this;
            msmq.ReceiveCompleted += new ReceiveCompletedEventHandler(msmq_ReceiveCompleted);
            
        }

        //Function:     btnStart_Click
        //Description:  Starts reading when clicked
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtQueueServer.Text == "")
            {
                MessageBox.Show("Message Queue Server required");
            }
            else
            {
                msmq.Path = "Formatname:Direct=os:" + txtQueueServer.Text + queueName;
                bRead = true;
                msmq.BeginReceive();
                IsRunning(true);
            }
        }

        //Function:     msmq_ReceiveCompleted
        //Description:  receives the message, writes it to the database.
        void msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                string message = e.Message.Body.ToString();
                dbw.WriteToDatabase(message);
             
                msmq.EndReceive(e.AsyncResult);
                if (chkCount.Checked)
                {
                    txtRemaining.Text = GetMessageCount(msmq).ToString();
                }
                Application.DoEvents();
                if (bRead)
                {
                    msmq.BeginReceive();
                }
            }
            catch
            {
                MessageBox.Show("Unhandled Exception");
            }
        }


        //Function:     btnStop_Click
        //Description:  stops reading when clicked
        private void btnStop_Click(object sender, EventArgs e)
        {
            bRead = false;
            IsRunning(false);
        }


        //Function:     GetMessageCount
        //Description:  Counts all messages in the message q. 
        private int GetMessageCount(MessageQueue m)
        {
            Int32 count = 0;
            MessageEnumerator msgEnum = m.GetMessageEnumerator2();
            while (msgEnum.MoveNext(new TimeSpan(0, 0, 0)))
            {
                count++;
            }
            return count;
        }


        //Function:     IsRunning
        //Description:  Toggles the availability to click buttons based on whether or not the reader is running
        private void IsRunning(Boolean state)
        {
            if (state == true)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                //btnSingleRead.Enabled = false;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                //btnSingleRead.Enabled = true;
            }
        }

        //Function:     btnPurgeQ_Click
        //Description:  Purges the q when the button is clicked.
        private void btnPurgeQ_Click(object sender, EventArgs e)
        {
            msmq.Purge();
        }

        //Function:     QueueReaderForm_Load
        //Description:  When the form loads it sets the computer name to find the msg q
        private void QueueReaderForm_Load(object sender, EventArgs e)
        {
            txtQueueServer.Text = System.Windows.Forms.SystemInformation.ComputerName;
            IsRunning(false);

        }

     
    }
}

