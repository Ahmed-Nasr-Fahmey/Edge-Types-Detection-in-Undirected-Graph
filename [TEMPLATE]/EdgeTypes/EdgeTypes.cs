using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
  
    public static class EdgeTypes
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Detect & count the edge types of the given UNDIRECTED graph by applying COMPLETE-DFS on the entire graph 
        /// NOTE: during search, break ties (if any) by selecting the verices in ASCENDING numeric order
        /// </summary>
        /// <param name="vertices">array of vertices in the graph (named from 0 to |V| - 1)</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <returns>return array of 3 numbers: outputs[0] number of backward edges, outputs[1] number of forward edges, outputs[2] number of cross edges</returns>
        public static int[] DetectEdges(int[] vertices, KeyValuePair<int, int>[] edges)
        {
            List<int>[] GraphListNodes = new List<int>[vertices.Length];

            
            Byte[] _nodeColors_ = new Byte[vertices.Length]; // contains for each vertix 0 (white) OR 1 (Gray)
            
            int _countEdges_ = 0;

            int[] parentNodes = new int[vertices.Length];


            foreach (int Vertix in vertices)// ..add the vertices in the list.
            {
                GraphListNodes[Vertix] = new List<int>();
            }
            foreach (var Edge in edges) //.. For each edge, the loop is adding the "to" vertex to the adjacency list of the "from" vertex, and vice versa, since this is an undirected graph.
            {
                GraphListNodes[Edge.Key].Add(Edge.Value);
                GraphListNodes[Edge.Value].Add(Edge.Key);
            }

          


           
            foreach (int _vertex_ in vertices)
            {
                if (_nodeColors_[_vertex_] == 0)
                {

                    parentNodes[_vertex_] = _vertex_;
                    DFSAlgorithm_Visit(_vertex_, GraphListNodes, parentNodes, ref _countEdges_, _nodeColors_);
                }
            }

            return new int[] { _countEdges_, _countEdges_, 0 }; // BackwordCount = ForwordCount && CrossCount =0 becouse it Undirected graph.
        }

        private static void DFSAlgorithm_Visit(int vertix, List<int>[] GraphListNodes, int[] parentNode, ref int _countEdges_, Byte[] _nodeColors_)
        {
            
            _nodeColors_[vertix] = 1; // become this node visited.   **discovered**

            
            foreach (int Adjacent in GraphListNodes[vertix])
            {
                if (_nodeColors_[Adjacent] == 0) // check it visited or not?
                {
                    parentNode[Adjacent] = vertix;
                    DFSAlgorithm_Visit(Adjacent, GraphListNodes, parentNode , ref _countEdges_, _nodeColors_);
                }
                else if (Adjacent != parentNode[vertix] && vertix < Adjacent)
                {
                    _countEdges_++; //detect the backword age
                }
            }
        }


        #endregion
    }
}
