/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");
 // var  del = require('del');
var webroot = "./wwwroot/";

var paths = {
    js: webroot + "js/**/*.js"
    , minJs: webroot + "js/**/*.min.js"
    , css: webroot + "css/**/*.css"
    , minCss: webroot + "css/**/*.min.css"
    , concatJsDest: webroot + "js/site.min.js"
    , concatCssDest: webroot + "css/site.min.css"
    , scripts: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map', 'scripts/*.js', 'scripts/*.ts', 'scripts/*.map']

};

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});


gulp.task('default:ts', function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/scripts'))
});

gulp.task('clean:ts', function () {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:ts"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);




var pathsAngular = {
    scripts: ['views/**/*.js', 'views/**/*.ts', 'views/**/*.map', 'views/*.js', 'views/*.ts', 'views/*.map'],
    libs: ['node_modules/angular2/bundles/angular2.js',
           'node_modules/angular2/bundles/angular2-polyfills.js',
           'node_modules/systemjs/dist/system.src.js',
           'node_modules/rxjs/bundles/Rx.js']
};

gulp.task('lib:ang', function () {
    gulp.src(pathsAngular.libs).pipe(gulp.dest('wwwroot/lib'))
});

gulp.task('clean:ang', function () {
    return del(['wwwroot/app/*', 'wwwroot/app/**/*']);
});

gulp.task('default:ang', ['lib:ang'], function () {
    gulp.src(pathsAngular.scripts).pipe(gulp.dest('wwwroot/app'))
});