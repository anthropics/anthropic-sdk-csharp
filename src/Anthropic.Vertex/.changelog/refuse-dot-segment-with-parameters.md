fix(vertex): throw on an empty model, and on one that starts with `;`, `.;` or `..;`, such as `"..;x"`, because a server that drops `;` and what follows it would read it as an empty or dot segment
