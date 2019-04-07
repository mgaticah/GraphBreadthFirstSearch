class Vertex {
    public string Name;
    public Neighbor AdjacencyList;
    public Vertex(string name, Neighbor neighbors) {
            this.Name = name;
            this.AdjacencyList = neighbors;
    }
}