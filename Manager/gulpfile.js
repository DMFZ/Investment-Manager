/// <binding AfterBuild='min' />
var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat");  
var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.angular = paths.webroot + "angular/**/*.js";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatAngularDest = paths.webroot + "angular/angular.min.js";
paths.css = paths.webroot +"css/**/*.css"

//gulp.task("bundle", function () {
//    return gulp.src([paths.js])
//        .pipe(concat(paths.concatJsDest))
//        .pipe(gulp.dest("./wwwroot"));
//}); 

//gulp.task("bundle", function () {  
//    return gulp.src([paths.js, "!" + paths.concatJsDest])  
//        .pipe(concat(paths.concatJsDest))  
//        .pipe(gulp.dest("./wwwroot"));  
//});

gulp.task("min", ["min:js","min:angular", "min:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js])
        .pipe(concat(paths.concatJsDest))
        .pipe(gulp.dest("./wwwroot"));
});

gulp.task("min:angular", function () {
    return gulp.src([paths.angular])
        .pipe(concat(paths.concatAngularDest))
        .pipe(gulp.dest("./wwwroot"));
});

gulp.task("min:css", function () {
    return gulp.src([paths.js])
        .pipe(concat(paths.concatJsDest))
        .pipe(gulp.dest("./wwwroot"));
    return merge(tasks);
});

