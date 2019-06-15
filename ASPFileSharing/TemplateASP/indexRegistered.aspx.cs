using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class indexRegistered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                HttpContext.Current.Session["downloads"] = new List<Tuple<int, string>>();
                HttpContext.Current.Session["blackList"] = new List<string>();
            }
        }


        [WebMethod]
        public static string searchFiles(string keywords)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            string html = "<tr><th>File</th><th></th></tr>";
            List<string> slist = dbUtil.getFiles(keywords);
            for (int i = 0; i < slist.Count; i++)
            {
                html += "<tr><td>" + slist[i] + "</td>"
                     + "<td onclick =\"showChunks('" + dbUtil.getId(slist[i]) + "')\">Show</td>" +
                    "</tr>";
            }
            return html;
        }
        [WebMethod]
        public static string showPeers()
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            string html = "<tr><th>Peers</th><th>Add to Black List</th></tr>";
            List<string> slist = dbUtil.getPeers();
            for (int i = 0; i < slist.Count; i++)
            {
                html += "<tr><td>" + slist[i] + "</td>"
                     + "<td onclick =\"addPeerBlack('" + slist[i] + "')\">Add</td>" +
                    "</tr>";
            }
            return html;
        }


        [WebMethod]
        public static string showAllChunks(int fileId)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            List<string> blackList = (List<string>)HttpContext.Current.Session["blackList"];

            List<int> ids = dbUtil.getChunksFile(fileId);
            string html = "";
            html += "<tr><th>Chunk Id</th><th> Peer</th><th>Choose</th></tr>";
            for (int i = 0; i < ids.Count(); i++)
            {
                System.Diagnostics.Debug.Write(ids[i] + "\n");
                List<string> peers = dbUtil.getPeersChunk(ids[i]);
                for (int j = 0; j < peers.Count(); j++)
                {
                    if (!blackList.Contains(peers[j]))
                    {
                        html += "<tr><td>" + ids[i] + "</td><td>" + peers[j] +
                            "</td><td><input type=\"checkbox\" onclick=\"addPeer('" + ids[i] + "','" + peers[j] + "')\"></td>" +
                            "</tr>";
                    }
                }
            }
            return html;
        }

        [WebMethod]
        public static void addPeerChunks(int chunkId, string peerName)
        {
            var tuple = Tuple.Create(chunkId, peerName);
            List<Tuple<int, string>> list = (List<Tuple<int, string>>)HttpContext.Current.Session["downloads"];
            list.Add(tuple);
            System.Diagnostics.Debug.Write(tuple.Item2);
            HttpContext.Current.Session["downloads"] = list;
        }

        [WebMethod]
        public static void addPeerBlackList(string peerName)
        {

            List<string> list = (List<string>)HttpContext.Current.Session["blackList"];
            list.Add(peerName);
            HttpContext.Current.Session["blackList"] = list;
            System.Diagnostics.Debug.Write(list);
        }


        [WebMethod]
        public static void removePeerBlackList(string peerName)
        {

            List<string> list = (List<string>)HttpContext.Current.Session["blackList"];
            list.Remove(peerName);
            HttpContext.Current.Session["blackList"] = list;
            System.Diagnostics.Debug.Write(list);
        }



        [WebMethod]
        public static string nextShow()
        {
            List<Tuple<int, string>> list = (List<Tuple<int, string>>)HttpContext.Current.Session["downloads"];
            string html = "<tr><td>Chunkd</td><td>PeerName</td></tr>";


            for (int i = 0; i < list.Count(); i++)
            {
                System.Diagnostics.Debug.Write(list[i].Item2);
                html += "<tr><td>" + list[i].Item1 + "</td><td>" + list[i].Item2 + "</td></tr>";
            }
            return html;
        }

        [WebMethod]
        public static string selectBlackList()
        {
            List<string> blackList = (List<string>)HttpContext.Current.Session["blackList"];
            string html = "<tr><td>PeerName</td><td>Remove from BlackList</td></tr>";
            if (blackList.Count() > 0)
            {
                for (int i = 0; i < blackList.Count(); i++)
                {
                    html += "<tr><td>" + blackList[i]
                       + "<td onclick =\"removePeerBlack('" + blackList[i] + "')\">Remove</td>" +
                        "</tr>";
                }
            }
            return html;
        }
    }
}