class Neighbor {
    public int VertexNum;
    public Neighbor Next;
    public Neighbor(int vertexNumber, Neighbor neighbor) {
            this.VertexNum = vertexNumber;
            Next = neighbor;
    }
}